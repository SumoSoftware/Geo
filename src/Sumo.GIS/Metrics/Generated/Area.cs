using System;
using System.Collections.Generic;

namespace Sumo.GIS.Metrics
{
    public partial class Area : IEquatable<Area>, IComparable<Area>, IComparable
    {
        public int CompareTo(Area other)
        {
            return Value.CompareTo(other.ConvertTo(Units).Value);
        }

        public int CompareTo(object obj)
        {
            return CompareTo(obj as Area);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Area);
        }

        public bool Equals(Area other)
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

        public static bool operator ==(Area area1, Area area2)
        {
            return EqualityComparer<Area>.Default.Equals(area1, area2);
        }

        public static bool operator !=(Area area1, Area area2)
        {
            return !(area1 == area2);
        }

        public static explicit operator double(Area value)
        {
            return value.Value;
        }
    }
}
