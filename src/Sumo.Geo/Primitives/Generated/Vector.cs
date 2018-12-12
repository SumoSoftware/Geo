using Sumo.Geo.Metrics;
using System;
using System.Collections.Generic;

namespace Sumo.Geo.Primitives
{
    public partial class Vector : IEquatable<Vector>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Vector);
        }

        public bool Equals(Vector other)
        {
            return other != null &&
                   EqualityComparer<Angle>.Default.Equals(Heading, other.Heading) &&
                   EqualityComparer<Distance>.Default.Equals(Magnitude, other.Magnitude) &&
                   EqualityComparer<GeoPoint>.Default.Equals(Origin, other.Origin);
        }

        public override int GetHashCode()
        {
            var hashCode = -594542511;
            hashCode = hashCode * -1521134295 + EqualityComparer<Angle>.Default.GetHashCode(Heading);
            hashCode = hashCode * -1521134295 + EqualityComparer<Distance>.Default.GetHashCode(Magnitude);
            hashCode = hashCode * -1521134295 + EqualityComparer<GeoPoint>.Default.GetHashCode(Origin);
            return hashCode;
        }

        public static bool operator ==(Vector vector1, Vector vector2)
        {
            return EqualityComparer<Vector>.Default.Equals(vector1, vector2);
        }

        public static bool operator !=(Vector vector1, Vector vector2)
        {
            return !(vector1 == vector2);
        }
    }
}
