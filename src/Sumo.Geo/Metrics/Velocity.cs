using System;
using System.Collections.Generic;

namespace Sumo.Geo.Metrics
{
    public class Velocity : Speed, IEquatable<Velocity>
    {
        public Velocity()
        {
        }

        public Velocity(Distance distance, UnitsOfTime units, Angle heading) : base(distance, units)
        {
            Heading = heading;
        }

        public Angle Heading { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Velocity);
        }

        public bool Equals(Velocity other)
        {
            return other != null &&
                   base.Equals(other) &&
                   EqualityComparer<Angle>.Default.Equals(Heading, other.Heading);
        }

        public override int GetHashCode()
        {
            var hashCode = 560059979;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Angle>.Default.GetHashCode(Heading);
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

        public override string ToString()
        {
            return $"{base.ToString()} to {Heading}";
        }
    }
}
