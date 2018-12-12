using Sumo.Geo.Primitives;
using System.Collections.Generic;

namespace Sumo.Geo.Geographies
{
    public class Surface : Geography
    {
        public List<GeoPoint> ElevationGrid { get; set; }
    }
}
