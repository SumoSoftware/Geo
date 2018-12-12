using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;
using System;

namespace Sumo.Geo.Geographies
{
    public class Cooridor : Region
    {
        public Cooridor() { }

        public Cooridor(GeoPath path, Distance stroke)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            Stroke = stroke ?? throw new ArgumentNullException(nameof(stroke));
        }

        public GeoPath Path { get; set; }
        public Distance Stroke { get; set; }
    }
}
