using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;
using System;
using System.Collections.Generic;

namespace Sumo.Geo.Geographies
{
    public partial class Circle : Region, IEquatable<Circle>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Circle);
        }

        public bool Equals(Circle other)
        {
            return other != null &&
                   base.Equals(other) &&
                   _radiusInNauticalMiles == other._radiusInNauticalMiles &&
                   EqualityComparer<GeoPoint>.Default.Equals(Center, other.Center) &&
                   EqualityComparer<Distance>.Default.Equals(_radius, other._radius) &&
                   EqualityComparer<Distance>.Default.Equals(Radius, other.Radius);
        }

        public override int GetHashCode()
        {
            var hashCode = 1130478661;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _radiusInNauticalMiles.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<GeoPoint>.Default.GetHashCode(Center);
            hashCode = hashCode * -1521134295 + EqualityComparer<Distance>.Default.GetHashCode(_radius);
            hashCode = hashCode * -1521134295 + EqualityComparer<Distance>.Default.GetHashCode(Radius);
            return hashCode;
        }

        public static bool operator ==(Circle circle1, Circle circle2)
        {
            return EqualityComparer<Circle>.Default.Equals(circle1, circle2);
        }

        public static bool operator !=(Circle circle1, Circle circle2)
        {
            return !(circle1 == circle2);
        }
    }
}
