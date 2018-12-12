using System;
using System.Collections.Generic;

namespace Sumo.Geo.Primitives
{
    public partial class Rectangle : IEquatable<Rectangle>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Rectangle);
        }

        public bool Equals(Rectangle other)
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

        public static bool operator ==(Rectangle rectangle1, Rectangle rectangle2)
        {
            return EqualityComparer<Rectangle>.Default.Equals(rectangle1, rectangle2);
        }

        public static bool operator !=(Rectangle rectangle1, Rectangle rectangle2)
        {
            return !(rectangle1 == rectangle2);
        }
    }
}
