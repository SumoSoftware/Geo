using Sumo.GIS.GeometricFigures;
using System;
using System.Collections.Generic;

namespace Sumo.GIS.Metrics
{
    public partial class Displacement : IEquatable<Displacement>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Displacement);
        }

        public bool Equals(Displacement other)
        {
            return other != null &&
                   EqualityComparer<Angle>.Default.Equals(Azimuth, other.Azimuth) &&
                   EqualityComparer<Distance>.Default.Equals(Distance, other.Distance) &&
                   EqualityComparer<Point>.Default.Equals(Origin, other.Origin);
        }

        public override int GetHashCode()
        {
            var hashCode = -594542511;
            hashCode = hashCode * -1521134295 + EqualityComparer<Angle>.Default.GetHashCode(Azimuth);
            hashCode = hashCode * -1521134295 + EqualityComparer<Distance>.Default.GetHashCode(Distance);
            hashCode = hashCode * -1521134295 + EqualityComparer<Point>.Default.GetHashCode(Origin);
            return hashCode;
        }

        public static bool operator ==(Displacement vector1, Displacement vector2)
        {
            return EqualityComparer<Displacement>.Default.Equals(vector1, vector2);
        }

        public static bool operator !=(Displacement vector1, Displacement vector2)
        {
            return !(vector1 == vector2);
        }
    }
}
