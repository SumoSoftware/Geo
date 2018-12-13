using Sumo.Geo.Primitives;
using System;
using System.Collections.Generic;

namespace Sumo.Geo.Geographies
{
    public partial class Box : IEquatable<Box>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Box);
        }

        public bool Equals(Box other)
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

        public static bool operator ==(Box rectangle1, Box rectangle2)
        {
            return EqualityComparer<Box>.Default.Equals(rectangle1, rectangle2);
        }

        public static bool operator !=(Box rectangle1, Box rectangle2)
        {
            return !(rectangle1 == rectangle2);
        }
    }
}
