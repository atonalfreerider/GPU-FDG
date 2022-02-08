using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using GPU_FDG.Database;

namespace GPU_FDG.DemoRandom;

/// <summary>
/// Randomly generates nodes and edges in a graph and runs for an amount of iterations. The output is written to
/// a database.
///
/// Uses a Szudzik paring and deparing algorithm for unique edges.
/// </summary>
static class DemoRandomGraph
{
    static readonly Random rand = new();

    public static void RunDemoGraph(Program.Args args)
    {
        ForceDirectedGraph forceDirectedGraph = new(args.RepulsiveForce, args.SpringForce);

        ForceDirectedGraph.Node node0 = forceDirectedGraph.AddNodeToGraph(0);
        node0.Position = new Vector3(0, 0, 0);

        Dictionary<uint, ForceDirectedGraph.Node> randomNodes =
            new Dictionary<uint, ForceDirectedGraph.Node> {{0, node0}};
        double scaleFactor = args.NumRandNodes / 100d;
        if (scaleFactor < 10)
        {
            scaleFactor = 10;
        }

        for (int i = 1; i < args.NumRandNodes; i++)
        {
            ForceDirectedGraph.Node newNode = forceDirectedGraph.AddNodeToGraph((uint) i);
            newNode.Position = new Vector3(
                (float) (rand.NextDouble() * scaleFactor - scaleFactor * .5d),
                (float) (rand.NextDouble() * scaleFactor - scaleFactor * .5d),
                (float) (rand.NextDouble() * scaleFactor - scaleFactor * .5d));
            randomNodes.Add((uint) i, newNode);
        }

        HashSet<ulong> edgeCombinations = new HashSet<ulong>();
        for (int i = 0; i < args.NumRandConnections; i++)
        {
            uint nodeAIdx = (uint) rand.Next(1, args.NumRandNodes);
            uint nodeBIdx = (uint) rand.Next(1, args.NumRandNodes);

            if (nodeAIdx == nodeBIdx) continue;

            // pair the edge using Szudzik
            ulong hash = tupleBase.uintSzudzik2tupleCombine(nodeAIdx, nodeBIdx);

            if (edgeCombinations.Contains(hash)) continue;

            edgeCombinations.Add(hash);

            ForceDirectedGraph.Node nodeA = randomNodes[nodeAIdx];
            ForceDirectedGraph.Node nodeB = randomNodes[nodeBIdx];
                
            nodeA.MyEdges.Add(nodeBIdx);
            nodeB.MyEdges.Add(nodeAIdx);
        }

        Vector3[] results = forceDirectedGraph.RunGraph(args.Iterations);

        Console.WriteLine($"Writing to {args.DbPath}");
            
        SqliteOutput output = new(args.DbPath);
            
        // de-pair the edge to recover the original nodes
        IEnumerable<uint[]> edgePairs = edgeCombinations
            .Select(tupleBase.uintSzudzik2tupleReverse);
        output.Serialize(edgePairs, results);
    }
}