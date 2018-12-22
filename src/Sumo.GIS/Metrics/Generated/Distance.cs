using System;
using System.Collections.Generic;

namespace Sumo.GIS.Metrics
{
    public partial class Distance : IEquatable<Distance>, IComparable<Distance>, IComparable
    {
        public int CompareTo(Distance other)
        {
            return Value.CompareTo(other.ConvertTo(Units).Value);
        }

        public int CompareTo(object obj)
        {
            return CompareTo(obj as Distance);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Distance);
        }

        public bool Equals(Distance other)
        {
            return other != null &&
                   Value == other.Value &&
                   Units == other.Units;
        }

        public override int GetHashCode()
        {
            var hashCode = -77776330;
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            hashCode = hashCode * -1521134295 + Units.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Distance distance1, Distance distance2)
        {
            return EqualityComparer<Distance>.Default.Equals(distance1, distance2);
        }

        public static bool operator !=(Distance distance1, Distance distance2)
        {
            return !(distance1 == distance2);
        }

        public static bool operator <(Distance distance1, Distance distance2)
        {
            return distance1.Value < distance2.ConvertTo(distance1.Units).Value;
        }

        public static bool operator >(Distance distance1, Distance distance2)
        {
            return distance1.Value > distance2.ConvertTo(distance1.Units).Value;
        }

        public static bool operator <=(Distance distance1, Distance distance2)
        {
            return distance1.Value <= distance2.ConvertTo(distance1.Units).Value;
        }

        public static bool operator >=(Distance distance1, Distance distance2)
        {
            return distance1.Value >= distance2.ConvertTo(distance1.Units).Value;
        }

        public static explicit operator double(Distance value)
        {
            return value.Value;
        }

        public static Distance operator +(Distance distance1, Distance distance2)
        {
            var value = distance1.Value + distance2.ConvertTo(distance1.Units).Value;
            return new Distance(value, distance1.Units);
        }

        public static Distance operator -(Distance distance1, Distance distance2)
        {
            var value = distance1.Value - distance2.ConvertTo(distance1.Units).Value;
            return new Distance(value, distance1.Units);
        }

        public static Distance operator *(Distance distance, double operand)
        {
            var value = distance.Value * operand;
            return new Distance(value, distance.Units);
        }

        public static Distance operator /(Distance distance, double denominator)
        {
            if(denominator == 0.0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(denominator)} out of range. Divsion by zero.");
            }
            var value = distance.Value / denominator;
            return new Distance(value, distance.Units);
        }

    }
}
