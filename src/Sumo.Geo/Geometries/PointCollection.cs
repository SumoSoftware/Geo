using System;
using System.Collections.Generic;

namespace Sumo.Geo.Geometries
{
    public partial class PointCollection : IGeometry
    {
        public PointCollection()
        {
            Coordinates = new List<Point>();
        }

        public PointCollection(IEnumerable<Point> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }

            Coordinates = new List<Point>(points);
        }

        public List<Point> Coordinates { get; }

        public override string ToString()
        {
            return $"[{String.Join(",", Coordinates)}]";
        }
    }
}
