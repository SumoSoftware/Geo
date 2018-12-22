using Sumo.GIS.GeometricFigures;
using System;

namespace Sumo.GIS.Metrics
{
    //todo: add Aspect: 
    //Aspect: [GIS processing] Aspect is the slope direction on a terrain surface. Aspect is measured clockwise starting North as 0° to 360° North again with flat areas given a value of -1 (or 0 degrees).

    /// <summary>
    /// Displacement is a vector that describes the relationship between two points.
    /// </summary>
    public partial class Displacement : IMetric
    {
        public Displacement() { }

        public Displacement(Point origin, Angle azimuth, Distance distance)
        {
            Origin = origin;
            Azimuth = azimuth;
            Distance = distance;
        }

        public Angle Azimuth { get; }
        public Distance Distance { get; }
        public Point Origin { get; }

        public override string ToString()
        {
            return String.Format($"[{Origin}, {Azimuth}, {Distance}]");
        }
    }
}
