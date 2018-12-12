using Sumo.Geo.Metrics;
using System;

namespace Sumo.Geo.Primitives
{
    public partial class GeoBox
    {
        public GeoBox()
        {
            NorthWest = new GeoPoint();
            SouthEast = new GeoPoint();
        }

        public GeoBox(GeoPoint northWest, GeoPoint southEast)
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

        public GeoPoint GetCentroid()
        {
            return new GeoPoint(
                (NorthWest.Latitude + SouthEast.Latitude) / 2.0,
                (NorthWest.Longitude + SouthEast.Longitude) / 2.0);
        }

        public Area GetArea()
        {
            var widthSegment = new LineSegment(NorthWest, new GeoPoint(NorthWest.Latitude, SouthEast.Longitude));
            var heightSegment = new LineSegment(NorthWest, new GeoPoint(SouthEast.Latitude, NorthWest.Longitude));
            var area = widthSegment.GetDistance().Value * heightSegment.GetDistance().Value;
            return new Area(area, UnitsOfLength.NauticalMile);
        }

        public override string ToString()
        {
            return String.Format($"[{NorthWest}, {SouthEast}]");
        }
    }
}
