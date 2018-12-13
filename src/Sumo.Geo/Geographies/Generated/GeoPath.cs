using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.Geo.Geographies
{
    public partial class GeoPath : Geography, IEquatable<GeoPath>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as GeoPath);
        }

        public bool Equals(GeoPath other)
        {
            return other != null &&
                   Points.SequenceEqual(other.Points) &&
                   IsClosed == other.IsClosed;
        }

        public override int GetHashCode()
        {
            var hashCode = 87000715;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<GeoPoint>>.Default.GetHashCode(Points);
            hashCode = hashCode * -1521134295 + IsClosed.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(GeoPath path1, GeoPath path2)
        {
            return EqualityComparer<GeoPath>.Default.Equals(path1, path2);
        }

        public static bool operator !=(GeoPath path1, GeoPath path2)
        {
            return !(path1 == path2);
        }
    }
}
