using Sumo.Geo.Primitives;
using System;
using System.Collections.Generic;

namespace Sumo.Geo.Geographies
{
    public abstract partial class Geography : IEquatable<Geography>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Geography);
        }

        public bool Equals(Geography other)
        {
            return other != null &&
                   EqualityComparer<GeoBox>.Default.Equals(_bounds, other._bounds) &&
                   EqualityComparer<GeoBox>.Default.Equals(Bounds, other.Bounds);
        }

        public override int GetHashCode()
        {
            var hashCode = 1875757263;
            hashCode = hashCode * -1521134295 + EqualityComparer<GeoBox>.Default.GetHashCode(_bounds);
            hashCode = hashCode * -1521134295 + EqualityComparer<GeoBox>.Default.GetHashCode(Bounds);
            return hashCode;
        }

        public static bool operator ==(Geography geography1, Geography geography2)
        {
            return EqualityComparer<Geography>.Default.Equals(geography1, geography2);
        }

        public static bool operator !=(Geography geography1, Geography geography2)
        {
            return !(geography1 == geography2);
        }
    }
}
