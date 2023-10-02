using System.Collections.Generic;
using UnityEngine;

namespace EdgePathFinder
{
    public class EdgePathFinder : IPathFinder
    {
        IEnumerable<Vector2> IPathFinder.GetPath(Vector2 A, Vector2 C, IEnumerable<Edge> edges)
        {
            IEnumerator<Edge> enumerator = edges.GetEnumerator();

            if (DataIsValid(enumerator))
            {

            }

            List<Vector2> list = new List<Vector2>
        {
            A
        };

            Vector2 lastCalculated = (enumerator.Current.Start + enumerator.Current.End) / 2;
            list.Add(lastCalculated);
            Vector2 prevCalculated = lastCalculated;

            while (enumerator.MoveNext())
            {

                lastCalculated = (enumerator.Current.Start + enumerator.Current.End) / 2;
                list.Add(lastCalculated);
            }
            list.Add(C);

            return list;
        }

        private bool DataIsValid(IEnumerator<Edge> enumerator)
        {
            while (enumerator.MoveNext())
            {
                if (!EdgeRectsAreIntersectedCorrectly(enumerator.Current))
                    return false;
            }
            return true;
        }

        private bool EdgeRectsAreIntersectedCorrectly(Edge current)
        {
            return
                //poins both are in the edge
                PointLaysAtEdge(current.First, current.Start) &&
                PointLaysAtEdge(current.First, current.End) &&
                //points both are in the same edge
                PointsAreValidlyPlaced(current.Start, current.End, new Vector2(current.First.Min.x, current.First.Max.x), new Vector2(current.First.Min.y, current.First.Max.y)) &&
                //same for second rect
                PointLaysAtEdge(current.Second, current.Start) &&
                PointLaysAtEdge(current.Second, current.End) &&
                PointsAreValidlyPlaced(current.Start, current.End, new Vector2(current.Second.Min.x, current.Second.Max.x), new Vector2(current.Second.Min.y, current.Second.Max.y));
        }

        private bool PointsAreValidlyPlaced(Vector3 start, Vector3 end, Vector2 xMinMax, Vector2 yMinMax)
        {

            if (start.x == end.x)
                return start.x == xMinMax.x || start.x == xMinMax.y;

            else if (start.y == end.y)
                return start.y == yMinMax.y || start.y == yMinMax.y;

            else return false;
        }

        //is point at the edge of rect
        private bool PointLaysAtEdge(Rectangle first, Vector3 point)
        {
            if (point.x == first.Min.x || point.x == first.Max.x)
                return LaysInline(first.Min.y, first.Max.y, point.y);

            else if (point.y == first.Min.y || point.y == first.Max.y)
                return LaysInline(first.Min.x, first.Max.x, point.x);

            else
                return false;
        }

        //does value is between two other values
        private bool LaysInline(float x1, float x2, float target)
        {
            if (x1 < x2)
                return x1 < target && target < x2;
            else
                return x2 < target && target < x1;
        }
    }
}