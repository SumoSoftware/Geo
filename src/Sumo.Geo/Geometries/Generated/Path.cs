using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.Geo.Geometries
{
    public partial class Path : IEquatable<Path>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Path);
        }

        public bool Equals(Path other)
        {
            return other != null &&
                   Coordinates.SequenceEqual(other.Coordinates);
        }

        public override int GetHashCode()
        {
            return -1484672504 + EqualityComparer<List<Point>>.Default.GetHashCode(Coordinates);
        }

        public static bool operator ==(Path polygon1, Path polygon2)
        {
            return EqualityComparer<Path>.Default.Equals(polygon1, polygon2);
        }

        public static bool operator !=(Path polygon1, Path polygon2)
        {
            return !(polygon1 == polygon2);
        }
    }
}
