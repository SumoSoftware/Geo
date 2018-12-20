using Sumo.Geo.Geometries;
using System;

namespace Sumo.Geo.Metrics
{
    /// <summary>
    /// Displacement is a vector that describes the relationship between two points.
    /// </summary>
    public partial class Displacement : IMetric
    {
        public Displacement() { }

        public Displacement(Point origin, Angle heading, Distance distance)
        {
            Origin = origin;
            Heading = heading;
            Distance = distance;
        }

        public Angle Heading { get; }
        public Distance Distance { get; }
        public Point Origin { get; }

        public override string ToString()
        {
            return String.Format($"{Origin}, {Heading}, {Distance}");
        }
    }
}
