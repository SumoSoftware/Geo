using System;
using System.Collections.Generic;
using System.Linq;
using Sumo.Geo.Primitives;

namespace Sumo.Geo.Geographies
{
    public partial class Path : Geography
    {
        public Path() { }

        public Path(IEnumerable<GeoPoint> points)
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

        protected override GeoBox GetBounds()
        {
            return new GeoBox(
                new GeoPoint(Points.Max(p => p.Latitude), Points.Min(p => p.Longitude)),
                new GeoPoint(Points.Min(p => p.Latitude), Points.Max(p => p.Longitude)));
        }
    }
}
