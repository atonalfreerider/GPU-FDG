using System;
using System.Collections.Generic;
using System.Numerics;

namespace GPU_FDG.Database;

/// <summary>
/// Loads a pre-defined graph from a database and runs for iterations.
///
/// The result positions are written to the same database.
/// </summary>
static class GenerateGraphFromData
{
    public static void RunGraph(Program.Args args)
    {
        SqliteInput input = new(args.DbPath);
        Dictionary<int, DbNode> nodes = input.DeSerialize();

        ForceDirectedGraph forceDirectedGraph = new(args.RepulsiveForce, args.SpringForce);

        Dictionary<int, ForceDirectedGraph.Node> fdgNodes = new Dictionary<int, ForceDirectedGraph.Node>();

        foreach ((int key, DbNode dbNode) in nodes)
        {
            ForceDirectedGraph.Node newNode = forceDirectedGraph.AddNodeToGraph((uint) key);
            newNode.Position = dbNode.Position;
            fdgNodes.Add(key, newNode);
        }

        foreach ((int key, DbNode dbNode) in nodes)
        {
            fdgNodes.TryGetValue(key, out ForceDirectedGraph.Node nodeA);
            foreach (int dependencyKey in dbNode.edgeIds)
            {
                fdgNodes.TryGetValue(dependencyKey, out ForceDirectedGraph.Node nodeB);
                nodeA?.MyEdges.Add((uint) dependencyKey);
                nodeB?.MyEdges.Add((uint) key);
            }
        }

        Vector3[] results = forceDirectedGraph.RunGraph(args.Iterations);

        Console.WriteLine($"Writing to {args.DbPath}");
            
        SqliteOutput output = new(args.DbPath);
        output.Serialize(results);
    }
}