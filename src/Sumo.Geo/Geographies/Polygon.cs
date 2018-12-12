using Sumo.Geo.Primitives;
using System;

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
    }
}
