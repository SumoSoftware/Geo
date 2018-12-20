using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.Geo.Geometries
{
    public partial class PointCollection : IEquatable<PointCollection>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as PointCollection);
        }

        public bool Equals(PointCollection other)
        {
            return other != null &&
                   this.SequenceEqual(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(PointCollection path1, PointCollection path2)
        {
            return EqualityComparer<PointCollection>.Default.Equals(path1, path2);
        }

        public static bool operator !=(PointCollection path1, PointCollection path2)
        {
            return !(path1 == path2);
        }
    }
}
