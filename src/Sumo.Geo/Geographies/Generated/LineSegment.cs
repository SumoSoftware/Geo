using Sumo.Geo.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.Geo.Geographies
{
    public partial class LineSegment : Geography, IEquatable<LineSegment>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as LineSegment);
        }

        public bool Equals(LineSegment other)
        {
            return other != null &&
                   Points.SequenceEqual(other.Points);
        }

        public override int GetHashCode()
        {
            return 480822998 + EqualityComparer<GeoPoint[]>.Default.GetHashCode(Points);
        }

        public static bool operator ==(LineSegment segment1, LineSegment segment2)
        {
            return EqualityComparer<LineSegment>.Default.Equals(segment1, segment2);
        }

        public static bool operator !=(LineSegment segment1, LineSegment segment2)
        {
            return !(segment1 == segment2);
        }
    }
}
