using System;
using System.Collections.Generic;

namespace Sumo.Geo.Metrics
{
    public partial class Speed : IEquatable<Speed>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Speed);
        }

        public bool Equals(Speed other)
        {
            return other != null &&
                   EqualityComparer<Speed>.Default.Equals(Speed, other.Speed) &&
                   Units == other.Units;
        }

        public override int GetHashCode()
        {
            var hashCode = 1591325966;
            hashCode = hashCode * -1521134295 + EqualityComparer<Speed>.Default.GetHashCode(Speed);
            hashCode = hashCode * -1521134295 + Units.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Speed speed1, Speed speed2)
        {
            return EqualityComparer<Speed>.Default.Equals(speed1, speed2);
        }

        public static bool operator !=(Speed speed1, Speed speed2)
        {
            return !(speed1 == speed2);
        }

        public static bool operator <(Speed speed1, Speed speed2)
        {
            return speed1.Distance.Value < speed2.ConvertTo(speed1.Units).Distance.ConvertTo(speed1.Distance.Units).Value;
        }

        public static bool operator >(Speed speed1, Speed speed2)
        {
            return speed1.Distance.Value > speed2.ConvertTo(speed1.Units).Distance.ConvertTo(speed1.Distance.Units).Value;
        }

        public static bool operator <=(Speed speed1, Speed speed2)
        {
            return speed1.Distance.Value <= speed2.ConvertTo(speed1.Units).Distance.ConvertTo(speed1.Distance.Units).Value;
        }

        public static bool operator >=(Speed speed1, Speed speed2)
        {
            return speed1.Distance.Value >= speed2.ConvertTo(speed1.Units).Distance.ConvertTo(speed1.Distance.Units).Value;
        }
    }
}
