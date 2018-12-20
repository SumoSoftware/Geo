using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.Geo.Geometries
{
    public partial class Path : IGeometry
    {
        public Path()
        {
            Coordinates = new List<OrderedPoint>();
        }

        public Path(IEnumerable<OrderedPoint> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }

            if (points.Count() < 3)
            {
                throw new ArgumentOutOfRangeException(nameof(points));
            }

            Coordinates = new List<OrderedPoint>(points.OrderBy((p) => p.Order));
        }

        public List<OrderedPoint> Coordinates { get; }

        public override string ToString()
        {
            return $"[{String.Join(",", Coordinates)}]";
        }
    }
}
