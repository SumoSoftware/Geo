﻿using System;
using System.Collections.Generic;

namespace Sumo.GIS.Metrics
{
    //todo: add IComparer to all the classes with IComparable
    public partial class Angle : IEquatable<Angle>, IComparable<Angle>, IComparable
    {
        public int CompareTo(object obj)
        {
            return CompareTo(obj as Angle);
        }

        public int CompareTo(Angle other)
        {
            return Value.CompareTo(other.ConvertTo(Units).Value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Angle);
        }

        public bool Equals(Angle other)
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

        public static bool operator ==(Angle heading1, Angle heading2)
        {
            return EqualityComparer<Angle>.Default.Equals(heading1, heading2);
        }

        public static bool operator !=(Angle heading1, Angle heading2)
        {
            return !(heading1 == heading2);
        }

        public static explicit operator double(Angle value)
        {
            return value.Value;
        }

        public static Angle operator +(Angle angle1, Angle angle2)
        {
            var value = angle1.Value + angle2.ConvertTo(angle1.Units).Value;
            return new Angle(value, angle1.Units);
        }

        public static Angle operator -(Angle angle1, Angle angle2)
        {
            var value = angle1.Value - angle2.ConvertTo(angle1.Units).Value;
            return new Angle(value, angle1.Units);
        }
    }
}
