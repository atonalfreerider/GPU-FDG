using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using ComputeSharp;

namespace GPU_FDG
{
    /// <summary>
    /// A force directed graph that uses Hooke's Law and Coulombs Law running with HLSL shader scripts
    ///
    /// Usage: 
    /// -Add nodes to the FDG by calling <see cref="AddNodeToGraph"/>
    /// </summary>
    public class ForceDirectedGraph
    {
        // internal variables

        /// <summary>
        /// All of the nodes in the graph. While running, the forces acting on the nodes will move the transform that
        /// is associated with that node.
        /// </summary>
        readonly Dictionary<uint, Node> nodes = new();

        // The constant that resembles Ke in Coulomb's Law to signify the strength of the repulsive force between nodes.
        readonly float universalRepulsiveForce;

        // The constant that resembles K in Hooke's Law to signify the strength of the attractive force on an edge.
        readonly float universalSpringForce;

        bool keepRunning = true;

        /// <summary>
        /// A graph of nodes and edges that uses Hooke's Law and Coulombs Law to create a 3D layout.
        /// </summary>
        /// <param name="universalRepulsiveForce">The constant repulsive force between all nodes.</param>
        /// <param name="universalSpringForce">The constant attractive force between nodes that share an edge.</param>
        public ForceDirectedGraph(
            float universalRepulsiveForce = 1,
            float universalSpringForce = .15f)
        {
            this.universalRepulsiveForce = universalRepulsiveForce;
            this.universalSpringForce = universalSpringForce;

            Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e)
            {
                // graceful termination
                e.Cancel = true;
                keepRunning = false;
            };
        }

        /// <summary>
        /// Adds a <see cref="Node"/> to the graph by a UNIQUE index.
        /// </summary>
        /// <param name="nodeIdx">A UNIQUE index for this node.</param>
        public Node AddNodeToGraph(uint nodeIdx)
        {
            Node newNode = new();
            nodes.Add(nodeIdx, newNode);

            return newNode;
        }

        /// <summary>
        /// Run kernels to calculate the balance forces that each node is experiencing from every other node in the map
        /// over a specified number of iterations.
        /// </summary>
        /// <param name="iterations">The number of iterations that the graph will run.</param>
        /// <returns>The result forces on each node in the order that they are represented in nodes.</returns>
        public Vector3[] RunGraph(int iterations)
        {
            if (universalSpringForce >= 1f)
            {
                Console.WriteLine("Universal Spring Force must be less than 1");
                return Array.Empty<Vector3>();
            }

            int nodeArrayLength = nodes.Count;

            // prepare native arrays for each calculation value
            Float3[] nodePositions = new Float3[nodeArrayLength];

            // amount of edges tracked per node so that the edge indices can be traversed
            // example:
            // node index   |   edge indices
            //  [0]         |   [12, 13, 17]
            //  [1]         |   [2, 5, 6, 8, 20]
            //  [2]         |   [0, 1]
            //
            // becomes
            // edge blocks: [3, 5, 2]
            // all edges: [12, 13, 17, 2, 5, 6, 8, 20, 0, 1]
            //
            // so node [0] owns the values of allEdges from 0-2, node 1 owns the values of allEdges from 3-7
            // and node [2] owns the values of allEdges from 8-9
            int[] edgeBlockLengths = new int[nodeArrayLength];
            int[] edgeBlockStartIndices = new int[nodeArrayLength];

            // all edges flattened together in one list
            List<int> allEdges = new List<int>();

            int count = 0;
            for (int idx = 0; idx < nodeArrayLength; idx++)
            {
                nodes.TryGetValue((uint)idx, out Node node);
                if (node == null) continue;

                nodePositions[idx] = node.Position;
                edgeBlockStartIndices[idx] = count;
                edgeBlockLengths[idx] = node.MyEdges.Count;
                count += node.MyEdges.Count;

                allEdges.AddRange(node.MyEdges.Select(Convert.ToInt32));
            }

            int[] edgeIndices = allEdges.ToArray();

            using ReadWriteBuffer<Float3> nodePositionsBuffer = Gpu.Default.AllocateReadWriteBuffer(nodePositions);
            using ReadOnlyBuffer<int> edgeBlockStartIndicesBuffer =
                Gpu.Default.AllocateReadOnlyBuffer(edgeBlockStartIndices);
            using ReadOnlyBuffer<int> edgeBlockLengthsBuffer = Gpu.Default.AllocateReadOnlyBuffer(edgeBlockLengths);
            using ReadOnlyBuffer<int> edgeIndicesBuffer = Gpu.Default.AllocateReadOnlyBuffer(edgeIndices);

            ForceKernelShader forceKernelShader = new(
                nodePositionsBuffer,
                edgeBlockStartIndicesBuffer,
                edgeBlockLengthsBuffer,
                edgeIndicesBuffer,
                nodeArrayLength,
                universalRepulsiveForce,
                universalSpringForce);

            for (int i = 1; i <= iterations; i++)
            {
                Console.WriteLine($"{i}/{iterations}");
                try
                {
                    Gpu.Default.For(nodeArrayLength, forceKernelShader);
                }
                catch (TargetInvocationException e)
                {
                    Console.WriteLine(e);
                }

                if (keepRunning == false)
                {
                    i = iterations;
                    Console.WriteLine("Terminating...");
                }
            }

            Float3[] resultNodePositions = nodePositionsBuffer.ToArray();
            Vector3[] results = new Vector3 [nodeArrayLength];
            for (int i = 0; i < nodeArrayLength; i++)
            {
                results[i] = resultNodePositions[i];
            }

            return results;
        }

        public class Node
        {
            public Vector3 Position;
            public readonly List<uint> MyEdges = new();
        }
    }

    [AutoConstructor]
    public readonly partial struct ForceKernelShader : IComputeShader
    {
        public readonly ReadWriteBuffer<Float3> nodePositions;

        // values and relationships
        public readonly ReadOnlyBuffer<int> edgeBlockStartIndices;
        public readonly ReadOnlyBuffer<int> edgeBlockLengths;
        public readonly ReadOnlyBuffer<int> edgeIndices;
        public readonly int nodeArrayLength;

        // physics
        public readonly float universalRepulsiveForce;
        public readonly float universalSpringForce;

        public void Execute()
        {
            // for this kernel, identify the index of the node that is getting acted upon
            int i = ThreadIds.X;

            Float3 resultForceAndDirection = new(0, 0, 0);

            // get the current 3D position of the node 
            Float3 nodeI = nodePositions[i];

            // iterate through all of this node's edges and determine the attractive and repulsive forces acting on it
            int edgeBlockStart = edgeBlockStartIndices[i];
            int edgeBlockLength = edgeBlockLengths[i];
            for (int z = edgeBlockStart; z < edgeBlockStart + edgeBlockLength; z++)
            {
                Float3 nodeJ = nodePositions[edgeIndices[z]];

                // determine the directional vector between the two nodes
                Float3 v = nodeI - nodeJ;
                float dot = Hlsl.Dot(v, v);
                float distance = Hlsl.Sqrt(dot);
                float dotRoot = Hlsl.Rsqrt(dot);

                Float3 direction = Hlsl.Mul(dotRoot, v);

                // Hooke's Law attractive force p2 <- p1
                // also divide by the amount of edges acting on this node as a dampening effect
                float hF = universalSpringForce * distance;

                resultForceAndDirection -= Hlsl.Mul(hF, direction);
            }

            // iterate through ALL nodes and determine the repulsive forces acting on this node
            // this is an O(n^2) operation
            for (int j = 0; j < nodeArrayLength; j++)
            {
                if (i == j)
                {
                    // don't compare the same node against itself -> the repulsive force would be infinite!
                    continue;
                }

                // another node in space that is acting on this node
                Float3 nodeJ = nodePositions[j];

                // determine the directional vector between the two nodes
                Float3 v = nodeI - nodeJ;
                float dot = Hlsl.Dot(v, v);
                float distance = Hlsl.Sqrt(dot);
                float dotRoot = Hlsl.Rsqrt(dot);

                Float3 direction = Hlsl.Mul(dotRoot, v);

                // Coulomb's Law repulsive force p2 -> p1 
                float cF = universalRepulsiveForce / (distance * distance);

                // sum the forces against all other forces acting on this node
                resultForceAndDirection += Hlsl.Mul(cF, direction);
            }

            if (Hlsl.IsNaN(resultForceAndDirection.X) ||
                Hlsl.IsNaN(resultForceAndDirection.Y) ||
                Hlsl.IsNaN(resultForceAndDirection.Z))
            {
                // catch asymptotic cases 
                resultForceAndDirection = new Float3(0, 0, 0);
            }

            // set the final node position after this frame
            nodePositions[i] += resultForceAndDirection;
        }
    }
}