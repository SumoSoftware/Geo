using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;
using System;
using System.Collections.Generic;

namespace Sumo.Geo.Geographies
{
    public partial class Corridor : GeoPointCollection, IEquatable<Corridor>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Corridor);
        }

        public bool Equals(Corridor other)
        {
            return other != null &&
                   base.Equals(other) &&
                   _widthInNauticalMiles == other._widthInNauticalMiles &&
                   EqualityComparer<Distance>.Default.Equals(_stroke, other._stroke) &&
                   EqualityComparer<Distance>.Default.Equals(Stroke, other.Stroke);
        }

        public override int GetHashCode()
        {
            var hashCode = 1217976947;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _widthInNauticalMiles.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Distance>.Default.GetHashCode(_stroke);
            hashCode = hashCode * -1521134295 + EqualityComparer<Distance>.Default.GetHashCode(Stroke);
            return hashCode;
        }

        public static bool operator ==(Corridor corridor1, Corridor corridor2)
        {
            return EqualityComparer<Corridor>.Default.Equals(corridor1, corridor2);
        }

        public static bool operator !=(Corridor corridor1, Corridor corridor2)
        {
            return !(corridor1 == corridor2);
        }
    }
}
