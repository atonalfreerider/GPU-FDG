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

    public static void RunDemoGraph(
        string dbPath, 
        int iterations,
        float springForce, 
        float repulsiveForce,
        float speedLimit,
        int numRandNodes,
        int numRandConnections)
    {
        ForceDirectedGraph forceDirectedGraph = new(repulsiveForce, springForce, speedLimit);

        ForceDirectedGraph.Node node0 = forceDirectedGraph.AddNodeToGraph(0);
        node0.Position = new Vector3(0, 0, 0);

        Dictionary<uint, ForceDirectedGraph.Node> randomNodes =
            new Dictionary<uint, ForceDirectedGraph.Node> {{0, node0}};
        double scaleFactor = numRandNodes / 100d;
        if (scaleFactor < 10)
        {
            scaleFactor = 10;
        }

        for (int i = 1; i < numRandNodes; i++)
        {
            ForceDirectedGraph.Node newNode = forceDirectedGraph.AddNodeToGraph((uint) i);
            newNode.Position = new Vector3(
                (float) (rand.NextDouble() * scaleFactor - scaleFactor * .5d),
                (float) (rand.NextDouble() * scaleFactor - scaleFactor * .5d),
                (float) (rand.NextDouble() * scaleFactor - scaleFactor * .5d));
            randomNodes.Add((uint) i, newNode);
        }

        HashSet<ulong> edgeCombinations = [];
        for (int i = 0; i < numRandConnections; i++)
        {
            uint nodeAIdx = (uint) rand.Next(1, numRandNodes);
            uint nodeBIdx = (uint) rand.Next(1, numRandNodes);

            if (nodeAIdx == nodeBIdx) continue;

            // pair the edge using Szudzik
            ulong hash = tupleBase.uintSzudzik2tupleCombine(nodeAIdx, nodeBIdx);

            if (!edgeCombinations.Add(hash)) continue;

            ForceDirectedGraph.Node nodeA = randomNodes[nodeAIdx];
            ForceDirectedGraph.Node nodeB = randomNodes[nodeBIdx];
                
            nodeA.MyEdges.Add(nodeBIdx);
            nodeB.MyEdges.Add(nodeAIdx);
        }

        Vector3[] results = forceDirectedGraph.RunGraph(iterations);

        Console.WriteLine($"Writing to {dbPath}");
            
        SqliteOutput output = new(dbPath);
            
        // de-pair the edge to recover the original nodes
        IEnumerable<uint[]> edgePairs = edgeCombinations
            .Select(tupleBase.uintSzudzik2tupleReverse);
        output.Serialize(edgePairs, results);
    }
}