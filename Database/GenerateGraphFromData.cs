using System;
using System.Collections.Generic;
using System.Numerics;

namespace GPU_FDG.Database
{
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

            ForceDirectedGraph forceDirectedGraph = new(args.RepulsiveForce, args.SpringForce, args.SpeedLimit);

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
                if (nodeA == null) continue;
                foreach (int dependencyKey in dbNode.edgeIds)
                {
                    uint uDependencyKey = (uint) dependencyKey;
                    fdgNodes.TryGetValue(dependencyKey, out ForceDirectedGraph.Node nodeB);
                    if (nodeB == null) continue;

                    if (nodeA.MyEdgesAndPower.ContainsKey(uDependencyKey))
                    {
                        nodeA.MyEdgesAndPower[uDependencyKey]++;
                    }
                    else
                    {
                        nodeA.MyEdgesAndPower.Add(uDependencyKey, 1);
                    }

                    uint uKey = (uint) key;
                    if (nodeB.MyEdgesAndPower.ContainsKey(uKey))
                    {
                        nodeB.MyEdgesAndPower[uKey]++;
                    }
                    else
                    {
                        nodeB.MyEdgesAndPower.Add(uKey, 1);
                    }
                }
            }

            Vector3[] results = forceDirectedGraph.RunGraph(args.Iterations);

            Console.WriteLine($"Writing to {args.DbPath}");
            
            SqliteOutput output = new(args.DbPath);
            output.Serialize(results);
        }
    }
}