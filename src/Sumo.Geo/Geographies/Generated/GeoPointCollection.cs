using Sumo.Geo.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.Geo.Geographies
{
    public partial class GeoPointCollection : Region, IEquatable<GeoPointCollection>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as GeoPointCollection);
        }

        public bool Equals(GeoPointCollection other)
        {
            return other != null &&
                   Points.SequenceEqual(other.Points);
        }

        public override int GetHashCode()
        {
            var hashCode = 87000715;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<GeoPoint>>.Default.GetHashCode(Points);
            return hashCode;
        }

        public static bool operator ==(GeoPointCollection path1, GeoPointCollection path2)
        {
            return EqualityComparer<GeoPointCollection>.Default.Equals(path1, path2);
        }

        public static bool operator !=(GeoPointCollection path1, GeoPointCollection path2)
        {
            return !(path1 == path2);
        }
    }
}
