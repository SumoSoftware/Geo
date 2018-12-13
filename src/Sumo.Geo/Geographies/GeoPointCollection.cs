using Sumo.Geo.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.Geo.Geographies
{
    public partial class GeoPointCollection : Region
    {
        public GeoPointCollection() { }

        public GeoPointCollection(IEnumerable<GeoPoint> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }

            Points = new List<GeoPoint>(points);
        }

        public List<GeoPoint> Points { get; }

        protected override void SetBounds()
        {
            NorthWest = new GeoPoint(Points.Max(p => p.Latitude), Points.Min(p => p.Longitude));
            SouthEast = new GeoPoint(Points.Min(p => p.Latitude), Points.Max(p => p.Longitude));
        }

        public override string ToString()
        {
            return $"[{String.Join(",", Points)}]";
        }
    }
}
