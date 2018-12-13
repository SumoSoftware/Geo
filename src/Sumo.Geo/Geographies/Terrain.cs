using Sumo.Geo.Primitives;
using System.Linq;

namespace Sumo.Geo.Geographies
{
    /// <summary>
    /// a raster of equidistant geo points with elevations that define a terrain surface
    /// </summary>
    public class Terrain : Geography
    {
        public Path Elevations { get; set; }

        protected override GeoBox GetBounds()
        {
            return new GeoBox(
                new GeoPoint(Elevations.Points.Max(p => p.Latitude), Elevations.Points.Min(p => p.Longitude)),
                new GeoPoint(Elevations.Points.Min(p => p.Latitude), Elevations.Points.Max(p => p.Longitude)));
        }
    }
}
