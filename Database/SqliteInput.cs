using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Numerics;

namespace GPU_FDG.Database;

public class SqliteInput(string dbPath)
{
    static readonly Random rand = new();

    public Dictionary<int, DbNode> DeSerialize()
    {
        Dictionary<int, DbNode> nodes = new Dictionary<int, DbNode>();
        if (string.IsNullOrEmpty(dbPath)) return nodes;

        string cs = $"URI=file:{dbPath}";

        using SQLiteConnection conn = new(cs);
        conn.Open();

        List<string> columnNames = ["id", "position_x", "position_y", "position_z"];

        using (IDbCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = CommandString(columnNames, "nodes");

            using (IDataReader reader = cmd.ExecuteReader())
            {
                Dictionary<string, int> indexes = ColumnIndexes(reader, columnNames);
                while (reader.Read())
                {
                    DbNode node = new DbNode
                    {
                        // sqlite dbs start from 1. shift to 0
                        id = reader.GetInt32(indexes["id"]) - 1
                    };

                    float x = reader[indexes["position_x"]].GetType() != typeof(DBNull) 
                        ? reader.GetFloat(indexes["position_x"])
                        : (float) rand.NextDouble();
                            
                    float y = reader[indexes["position_y"]].GetType() != typeof(DBNull) 
                        ? reader.GetFloat(indexes["position_y"])
                        : (float) rand.NextDouble();
                            
                    float z = reader[indexes["position_z"]].GetType() != typeof(DBNull) 
                        ? reader.GetFloat(indexes["position_z"])
                        : (float) rand.NextDouble();

                    Vector3 position = new(x, y, z);

                    node.Position = position;
                    nodes.Add(node.id, node);
                }
            }
        }

        return RetrieveEdges(conn, nodes);
    }

    static Dictionary<int, DbNode> RetrieveEdges(IDbConnection conn, Dictionary<int, DbNode> nodes)
    {
        List<string> columnNames = ["node1", "node2"];

        using IDbCommand cmd = conn.CreateCommand();
        cmd.CommandText = CommandString(columnNames, "edges");

        using IDataReader reader = cmd.ExecuteReader();
        Dictionary<string, int> indexes = ColumnIndexes(reader, columnNames);
        while (reader.Read())
        {
            // sqlite dbs start at 1. shift to 0.
            int nodeAidx = reader.GetInt32(indexes["node1"]) - 1;
            int nodeBidx = reader.GetInt32(indexes["node2"]) - 1;

            nodes.TryGetValue(nodeAidx, out DbNode nodeA);

            nodeA?.edgeIds.Add(nodeBidx);
        }

        return nodes;
    }

    static string CommandString(IEnumerable<string> columnNames, string tableName)
    {
        string cmd = columnNames.Aggregate(
            "SELECT ",
            (current, columnName) => current + $"{columnName}, ");

        // remove last comma
        cmd = cmd[..^2] + " ";
        cmd += $"FROM {tableName}";

        return cmd;
    }

    static Dictionary<string, int> ColumnIndexes(IDataRecord reader, IEnumerable<string> columnNames)
    {
        return columnNames
            .ToDictionary(
                columnName => columnName,
                reader.GetOrdinal);
    }
}