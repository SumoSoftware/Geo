using Sumo.Geo.Metrics;

namespace Sumo.Geo.Geometries
{
    public sealed partial class OrderedPoint : Point
    {
        public OrderedPoint() : base() { }

        public OrderedPoint(double latitude, double longitude, Distance elevation, int order) : base(latitude, longitude, elevation)
        {
            Order = order;
        }

        public OrderedPoint(Point point, int order) : base(point)
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
