using Sumo.Geo.Metrics;
using System;

namespace Sumo.Geo.Primitives
{
    public partial class Vector
    {
        public Vector() { }

        public Vector(GeoPoint origin, Angle heading, Distance magnitude)
        {
            Origin = origin;
            Heading = heading;
            Magnitude = magnitude;
        }

        public Angle Heading { get; set; }
        public Distance Magnitude { get; set; }
        public GeoPoint Origin { get; set; }


        public override string ToString()
        {
            return String.Format($"{Origin}, {Heading}, {Magnitude}");
        }
    }
}
