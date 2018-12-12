using System;
using System.Collections.Generic;

namespace Sumo.Geo.Metrics
{
    public partial class Area : IEquatable<Area>
    {
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
    }
}
