using System;

namespace Sumo.Geo.Primitives
{
    public partial class Rectangle
    {
        public Rectangle()
        {
            NorthWest = new GeoPoint();
            SouthEast = new GeoPoint();
        }

        public Rectangle(GeoPoint northWest, GeoPoint southEast)
        {
            NorthWest = northWest ?? throw new ArgumentNullException(nameof(northWest));
            SouthEast = southEast ?? throw new ArgumentNullException(nameof(southEast));
        }

        public GeoPoint NorthWest { get; }
        public GeoPoint SouthEast { get; }

        public bool Contains(GeoPoint point)
        {
            return
                point.Latitude <= NorthWest.Latitude &&
                point.Latitude >= SouthEast.Latitude &&
                point.Longitude >= NorthWest.Longitude &&
                point.Longitude <= SouthEast.Longitude;
        }

        public override string ToString()
        {
            return String.Format($"[{NorthWest}, {SouthEast}]");
        }
    }
}
