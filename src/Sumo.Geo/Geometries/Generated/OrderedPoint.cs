using System;
using System.Collections;
using System.Collections.Generic;

namespace Sumo.Geo.Geometries
{
    public sealed partial class OrderedPoint : Point, IComparable, IComparable<OrderedPoint>, IComparer, IEquatable<OrderedPoint>
    {
        public int Compare(object x, object y)
        {
            return ((OrderedPoint)x).CompareTo((OrderedPoint)y);
        }

        public int CompareTo(object obj)
        {
            return CompareTo((OrderedPoint)obj);
        }

        public int CompareTo(OrderedPoint other)
        {
            return Order.CompareTo(other.Order);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as OrderedPoint);
        }

        public bool Equals(OrderedPoint other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Order == other.Order;
        }

        public override int GetHashCode()
        {
            var hashCode = 1041847501;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Order.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(OrderedPoint point1, OrderedPoint point2)
        {
            return EqualityComparer<OrderedPoint>.Default.Equals(point1, point2);
        }

        public static bool operator !=(OrderedPoint point1, OrderedPoint point2)
        {
            return !(point1 == point2);
        }
    }
}
