using Sumo.Geo.Primitives;
using System;

namespace Sumo.Geo.Metrics
{
    public partial class Displacement
    {
        public Displacement() { }

        public Displacement(GeoPoint origin, Angle heading, Distance distance)
        {
            Origin = origin;
            Heading = heading;
            Distance = distance;
        }

        public Angle Heading { get; set; }
        public Distance Distance { get; set; }
        public GeoPoint Origin { get; set; }

        public override string ToString()
        {
            return String.Format($"{Origin}, {Heading}, {Distance}");
        }
    }
}
