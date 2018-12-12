using System;
using System.Collections.Generic;

namespace Sumo.Geo.Primitives
{
    public partial class GeoBox : IEquatable<GeoBox>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as GeoBox);
        }

        public bool Equals(GeoBox other)
        {
            return other != null &&
                   EqualityComparer<GeoPoint>.Default.Equals(NorthWest, other.NorthWest) &&
                   EqualityComparer<GeoPoint>.Default.Equals(SouthEast, other.SouthEast);
        }

        public override int GetHashCode()
        {
            var hashCode = -2037051170;
            hashCode = hashCode * -1521134295 + EqualityComparer<GeoPoint>.Default.GetHashCode(NorthWest);
            hashCode = hashCode * -1521134295 + EqualityComparer<GeoPoint>.Default.GetHashCode(SouthEast);
            return hashCode;
        }

        public static bool operator ==(GeoBox rectangle1, GeoBox rectangle2)
        {
            return EqualityComparer<GeoBox>.Default.Equals(rectangle1, rectangle2);
        }

        public static bool operator !=(GeoBox rectangle1, GeoBox rectangle2)
        {
            return !(rectangle1 == rectangle2);
        }
    }
}
