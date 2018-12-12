using Sumo.Geo.Primitives;
using System.Linq;

namespace Sumo.Geo.Geographies
{
    public class Surface : Geography
    {
        public GeoPath Elevations { get; set; }

        protected override GeoBox GetBounds()
        {
            return new GeoBox(
                new GeoPoint(Elevations.Points.Max(p => p.Latitude), Elevations.Points.Min(p => p.Longitude)),
                new GeoPoint(Elevations.Points.Min(p => p.Latitude), Elevations.Points.Max(p => p.Longitude)));
        }
    }
}
