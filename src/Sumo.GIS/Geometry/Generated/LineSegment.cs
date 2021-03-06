﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.GIS.Geometry
{
    public partial class LineSegment : IEquatable<LineSegment>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as LineSegment);
        }

        public bool Equals(LineSegment other)
        {
            return other != null &&
                   _points.SequenceEqual(other._points);
        }

        public override int GetHashCode()
        {
            return 480822998 + EqualityComparer<Point[]>.Default.GetHashCode(_points);
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
