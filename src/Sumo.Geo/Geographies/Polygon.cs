using Sumo.Geo.Primitives;
using System;
using System.Linq;

namespace Sumo.Geo.Geographies
{
    public class Polygon : Region
    {
        public Polygon() { }

        public Polygon(GeoPath perimeter)
        {
            Perimeter = perimeter ?? throw new ArgumentNullException(nameof(perimeter));
        }

        public GeoPath Perimeter { get; set; }

        public override GeoPoint GetCentroid()
        {
            throw new NotImplementedException();
        }

        protected override GeoBox GetBounds()
        {
            return new GeoBox(
                new GeoPoint(Perimeter.Points.Max(p => p.Latitude), Perimeter.Points.Min(p => p.Longitude)),
                new GeoPoint(Perimeter.Points.Min(p => p.Latitude), Perimeter.Points.Max(p => p.Longitude)));
        }

        protected override bool PrecisionContains(GeoPoint point)
        {
            throw new NotImplementedException();
        }
    }
}
