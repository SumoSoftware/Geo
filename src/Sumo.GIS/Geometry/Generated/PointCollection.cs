using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.GIS.Geometry
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

        public static bool operator ==(PointCollection collection1, PointCollection collection2)
        {
            return EqualityComparer<PointCollection>.Default.Equals(collection1, collection2);
        }

        public static bool operator !=(PointCollection collection1, PointCollection collection2)
        {
            return !(collection1 == collection2);
        }
    }
}
