using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.Geo.Geometries
{
    public partial class PointCollection : IEquatable<PointCollection>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as PointCollection);
        }

        public bool Equals(PointCollection other)
        {
            return other != null &&
                   Coordinates.SequenceEqual(other.Coordinates);
        }

        public override int GetHashCode()
        {
            var hashCode = 87000715;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Point>>.Default.GetHashCode(Coordinates);
            return hashCode;
        }

        public static bool operator ==(PointCollection path1, PointCollection path2)
        {
            return EqualityComparer<PointCollection>.Default.Equals(path1, path2);
        }

        public static bool operator !=(PointCollection path1, PointCollection path2)
        {
            return !(path1 == path2);
        }
    }
}
