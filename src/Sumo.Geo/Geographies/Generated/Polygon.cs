using Sumo.Geo.Primitives;
using System;
using System.Collections.Generic;

namespace Sumo.Geo.Geographies
{
    public partial class Polygon : Region, IEquatable<Polygon>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Polygon);
        }

        public bool Equals(Polygon other)
        {
            return other != null &&
                   base.Equals(other) &&
                   EqualityComparer<Path>.Default.Equals(Perimeter, other.Perimeter);
        }

        public override int GetHashCode()
        {
            var hashCode = -510461622;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Path>.Default.GetHashCode(Perimeter);
            return hashCode;
        }

        public static bool operator ==(Polygon polygon1, Polygon polygon2)
        {
            return EqualityComparer<Polygon>.Default.Equals(polygon1, polygon2);
        }

        public static bool operator !=(Polygon polygon1, Polygon polygon2)
        {
            return !(polygon1 == polygon2);
        }
    }
}
