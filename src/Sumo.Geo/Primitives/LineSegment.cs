using Sumo.Geo.Metrics;
using System;

namespace Sumo.Geo.Primitives
{
    public class LineSegment
    {
        public LineSegment()
        {
            Points = new Point[2];
        }

        public LineSegment(Point point1, Point point2)
        {
            Points = new Point[] { point1, point2 };
        }

        public Point[] Points { get; }

        public Distance Length()
        {
            return Points[0].GeodesicDistance(Points[1]);
        }

        public override string ToString()
        {
            return String.Format($"[{Points[0]}, {Points[1]}]");
        }
    }
}
