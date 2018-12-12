using Sumo.Geo.Metrics;
using System;
using System.Collections.Generic;

namespace Sumo.Geo.Primitives
{
    public class Vector : IEquatable<Vector>
    {
        public Vector() { }

        public Vector(Point origin, Angle heading, Distance magnitude)
        {
            Origin = origin;
            Heading = heading;
            Magnitude = magnitude;
        }

        public Angle Heading { get; set; }
        public Distance Magnitude { get; set; }
        public Point Origin { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vector);
        }

        public bool Equals(Vector other)
        {
            return other != null &&
                   EqualityComparer<Angle>.Default.Equals(Heading, other.Heading) &&
                   EqualityComparer<Distance>.Default.Equals(Magnitude, other.Magnitude) &&
                   EqualityComparer<Point>.Default.Equals(Origin, other.Origin);
        }

        public override int GetHashCode()
        {
            var hashCode = -594542511;
            hashCode = hashCode * -1521134295 + EqualityComparer<Angle>.Default.GetHashCode(Heading);
            hashCode = hashCode * -1521134295 + EqualityComparer<Distance>.Default.GetHashCode(Magnitude);
            hashCode = hashCode * -1521134295 + EqualityComparer<Point>.Default.GetHashCode(Origin);
            return hashCode;
        }

        public override string ToString()
        {
            return string.Format($"{Origin}, {Heading}, {Magnitude}");
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
