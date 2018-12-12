using System;
using System.Collections.Generic;

namespace Sumo.Geo.Primitives
{
    public partial class GeoPath 
    {
        public GeoPath() { }

        public GeoPath(IEnumerable<GeoPoint> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }

            Points = new List<GeoPoint>(points);
        }

        public List<GeoPoint> Points { get; }

        public bool IsClosed { get; set; }

        public override string ToString()
        {
            return $"[{String.Join(",", Points)}]";
        }
    }
}
