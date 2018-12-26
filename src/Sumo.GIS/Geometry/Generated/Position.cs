using Sumo.GIS.Metrics;
using System.Collections.Generic;

namespace Sumo.GIS.Geometry
{
    public partial class Position
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Position);
        }

        public bool Equals(Position other)
        {
            return other != null &&
                   base.Equals(other) &&
                   EqualityComparer<Distance>.Default.Equals(Elevation, other.Elevation);
        }

        public override int GetHashCode()
        {
            var hashCode = 898345338;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Distance>.Default.GetHashCode(Elevation);
            return hashCode;
        }

        public static bool operator ==(Position position1, Position position2)
        {
            return EqualityComparer<Position>.Default.Equals(position1, position2);
        }

        public static bool operator !=(Position position1, Position position2)
        {
            return !(position1 == position2);
        }
    }
}
