using System;
using System.Collections.Generic;

namespace Sumo.GIS.Metrics
{
    public partial class Velocity : Speed, IEquatable<Velocity>, IComparable<Velocity>, IComparable
    {
        public int CompareTo(Velocity other)
        {
            return base.CompareTo(other);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Velocity);
        }

        public bool Equals(Velocity other)
        {
            return other != null &&
                   base.Equals(other) &&
                   EqualityComparer<Angle>.Default.Equals(Azimuth, other.Azimuth);
        }

        public override int GetHashCode()
        {
            var hashCode = 560059979;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Angle>.Default.GetHashCode(Azimuth);
            return hashCode;
        }

        public static bool operator ==(Velocity velocity1, Velocity velocity2)
        {
            return EqualityComparer<Velocity>.Default.Equals(velocity1, velocity2);
        }

        public static bool operator !=(Velocity velocity1, Velocity velocity2)
        {
            return !(velocity1 == velocity2);
        }
    }
}
