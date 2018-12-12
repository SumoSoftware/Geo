using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;

namespace Sumo.Geo.Geographies
{
    public class Circle : Region
    {
        public GeoPoint Center { get; set; }
        public Distance Radius { get; set; }
    }
}
