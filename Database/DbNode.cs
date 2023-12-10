using System.Collections.Generic;
using System.Numerics;

namespace GPU_FDG.Database;

public class DbNode
{
    public int id;
    public Vector3 Position;
    public readonly Dictionary<int, float> edgeIdsAndPower = new();
}