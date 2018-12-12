using Sumo.Geo.Metrics;
using System;
using System.Collections.Generic;

namespace Sumo.Geo.Primitives
{
    public partial class GeoPoint : IEquatable<GeoPoint>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as GeoPoint);
        }

        public bool Equals(GeoPoint other)
        {
            return other != null &&
                   Latitude == other.Latitude &&
                   Longitude == other.Longitude &&
                   EqualityComparer<Distance>.Default.Equals(Elevation, other.Elevation);
        }

        public override int GetHashCode()
        {
            var hashCode = 1960202551;
            hashCode = hashCode * -1521134295 + Latitude.GetHashCode();
            hashCode = hashCode * -1521134295 + Longitude.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Distance>.Default.GetHashCode(Elevation);
            return hashCode;
        }

        public static bool operator ==(GeoPoint point1, GeoPoint point2)
        {
            return EqualityComparer<GeoPoint>.Default.Equals(point1, point2);
        }

        public static bool operator !=(GeoPoint point1, GeoPoint point2)
        {
            return !(point1 == point2);
        }
    }
}
