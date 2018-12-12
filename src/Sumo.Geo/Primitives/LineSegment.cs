using Sumo.Geo.Metrics;
using System;

namespace Sumo.Geo.Primitives
{
    public partial class LineSegment
    {
        public LineSegment()
        {
            Points = new GeoPoint[2];
        }

        public LineSegment(GeoPoint point1, GeoPoint point2)
        {
            Points = new GeoPoint[] { point1, point2 };
        }

        public GeoPoint[] Points { get; }

        /// <summary>
        /// returns geodesic distance (great arc)
        /// </summary>
        /// <returns></returns>
        public Distance GetDistance()
        {
            return Points[0].GetDistance(Points[1]);
        }

        public override string ToString()
        {
            return String.Format($"[{Points[0]}, {Points[1]}]");
        }
    }
}
