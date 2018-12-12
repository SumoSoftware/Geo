using Sumo.Geo.Metrics;

namespace Sumo.Geo.Primitives
{
    public sealed partial class OrderedGeoPoint : GeoPoint
    {
        public OrderedGeoPoint() : base() { }

        public OrderedGeoPoint(double latitude, double longitude, Distance elevation, int order) : base(latitude, longitude, elevation)
        {
            Order = order;
        }

        public OrderedGeoPoint(GeoPoint point, int order) : base(point)
        {
            Order = order;
        }

        public int Order { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}: {Order}";
        }
    }
}
