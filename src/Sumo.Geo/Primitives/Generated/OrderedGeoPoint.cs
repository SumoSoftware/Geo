using System;
using System.Collections;
using System.Collections.Generic;

namespace Sumo.Geo.Primitives
{
    public sealed partial class OrderedGeoPoint : GeoPoint, IComparable, IComparable<OrderedGeoPoint>, IComparer, IEquatable<OrderedGeoPoint>
    {
        public int Compare(object x, object y)
        {
            return ((OrderedGeoPoint)x).CompareTo((OrderedGeoPoint)y);
        }

        public int CompareTo(object obj)
        {
            return CompareTo((OrderedGeoPoint)obj);
        }

        public int CompareTo(OrderedGeoPoint other)
        {
            return Order.CompareTo(other.Order);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as OrderedGeoPoint);
        }

        public bool Equals(OrderedGeoPoint other)
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

        public static bool operator ==(OrderedGeoPoint point1, OrderedGeoPoint point2)
        {
            return EqualityComparer<OrderedGeoPoint>.Default.Equals(point1, point2);
        }

        public static bool operator !=(OrderedGeoPoint point1, OrderedGeoPoint point2)
        {
            return !(point1 == point2);
        }
    }
}
