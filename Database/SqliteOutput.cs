using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Numerics;

namespace GPU_FDG.Database
{
    /// <summary>
    /// Writes the result to an external database.
    /// </summary>
    public class SqliteOutput
    {
        readonly string DbPath;

        public SqliteOutput(string dbPath)
        {
            DbPath = dbPath;
        }

        public void Serialize(
            IEnumerable<uint[]> edgePairs,
            IEnumerable<Vector3> positions)
        {
            if (string.IsNullOrEmpty(DbPath)) return;

            if (File.Exists(DbPath))
            {
                File.Delete(DbPath);
            }

            string cs = $"URI=file:{DbPath}";

            using SQLiteConnection conn = new(cs);
            conn.Open();

            using (IDbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText =
                    @"CREATE TABLE nodes (
                          id INTEGER PRIMARY KEY ASC,
                          position_x REAL NOT NULL,
                          position_y REAL NOT NULL,
                          position_z REAL NOT NULL
                      )";
                cmd.ExecuteNonQuery();

                cmd.CommandText =
                    @"CREATE TABLE edges (
                          id INTEGER PRIMARY KEY ASC,
                          node1 INTEGER NOT NULL,
                          node2 INTEGER NOT NULL
                      )";
                cmd.ExecuteNonQuery();
            }

            InsertNodes(conn, positions.ToList());
            InsertEdges(conn, edgePairs);
        }

        public void Serialize(Vector3[] positions)
        {
            if (string.IsNullOrEmpty(DbPath)) return;

            string cs = $"URI=file:{DbPath}";

            using SQLiteConnection conn = new(cs);
            conn.Open();

            UpdateNodes(conn, positions.ToList());
        }

        static void InsertNodes(
            IDbConnection conn,
            IEnumerable<Vector3> positions)
        {
            using IDbCommand cmd = conn.CreateCommand();
            using IDbTransaction transaction = conn.BeginTransaction();
            cmd.CommandText =
                @"INSERT INTO nodes (
                          position_x,
                          position_y,
                          position_z
                      ) VALUES (
                          @PositionX,
                          @PositionY,
                          @PositionZ
                      )";

            foreach (Vector3 position in positions)
            {
                IDbDataParameter positionXParameter =
                    cmd.CreateParameter();
                positionXParameter.DbType = DbType.Double;
                positionXParameter.ParameterName = "@PositionX";
                positionXParameter.Value = position.X;
                cmd.Parameters.Add(positionXParameter);

                IDbDataParameter positionYParameter =
                    cmd.CreateParameter();
                positionYParameter.DbType = DbType.Double;
                positionYParameter.ParameterName = "@PositionY";
                positionYParameter.Value = position.Y;
                cmd.Parameters.Add(positionYParameter);

                IDbDataParameter positionZParameter =
                    cmd.CreateParameter();
                positionZParameter.DbType = DbType.Double;
                positionZParameter.ParameterName = "@PositionZ";
                positionZParameter.Value = position.Z;
                cmd.Parameters.Add(positionZParameter);

                cmd.ExecuteNonQuery();
            }

            transaction.Commit();
        }

        static void UpdateNodes(
            IDbConnection conn,
            IEnumerable<Vector3> positions)
        {
            using IDbCommand cmd = conn.CreateCommand();
            using IDbTransaction transaction = conn.BeginTransaction();
            int count = 1;
            foreach (Vector3 next in positions)
            {
                if (float.IsNaN(next.X + next.Y + next.Z))
                {
                    Console.WriteLine($"NaN: {count}");
                    count++;
                    continue;
                }
                cmd.CommandText = @"  
                        UPDATE nodes  
                        SET   
                            position_x = " + next.X + @",  
                            position_y = " + next.Y + @",  
                            position_z = " + next.Z + @"  
                        WHERE id = " + count;

                cmd.ExecuteNonQuery();

                count++;
            }

            transaction.Commit();
        }

        static void InsertEdges(
            IDbConnection conn,
            IEnumerable<uint[]> edges)
        {
            using IDbCommand cmd = conn.CreateCommand();
            using IDbTransaction transaction = conn.BeginTransaction();
            cmd.CommandText =
                @"INSERT INTO edges (
                          node1,
                          node2
                      ) VALUES (
                          @Node1,
                          @Node2
                      )";

            foreach (uint[] edge in edges)
            {
                IDbDataParameter node1Parameter = cmd.CreateParameter();
                node1Parameter.DbType = DbType.Int32;
                node1Parameter.ParameterName = "@Node1";
                node1Parameter.Value = (int) edge[0] + 1; // increment by one since dbs start at 1
                cmd.Parameters.Add(node1Parameter);

                IDbDataParameter node2Parameter = cmd.CreateParameter();
                node2Parameter.DbType = DbType.Int32;
                node2Parameter.ParameterName = "@Node2";
                node2Parameter.Value = (int) edge[1] + 1; // increment by one since dbs start at 1
                cmd.Parameters.Add(node2Parameter);

                cmd.ExecuteNonQuery();
            }

            transaction.Commit();
        }
    }
}