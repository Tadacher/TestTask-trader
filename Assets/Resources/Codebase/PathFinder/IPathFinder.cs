using System.Collections.Generic;
using UnityEngine;

namespace EdgePathFinder
{
    interface IPathFinder
    {
        IEnumerable<Vector2> GetPath(Vector2 A, Vector2 C, IEnumerable<Edge> edges);
    }
}