using Sumo.Geo.Metrics;
using System;

namespace Sumo.Geo.Primitives
{
    public partial class GeoBox : IGeoRegion
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

        private GeoPoint _centroid;
        public GeoPoint Centroid
        {
            get
            {
                if (_centroid == null)
                {
                    _centroid = GetCentroid();
                }

                return _centroid;
            }
        }

        public bool Contains(GeoPoint point)
        {
            return
                point.Latitude <= NorthWest.Latitude &&
                point.Latitude >= SouthEast.Latitude &&
                point.Longitude >= NorthWest.Longitude &&
                point.Longitude <= SouthEast.Longitude;
        }

        public bool Contains(IGeoRegion region)
        {
            return
                NorthWest.Longitude <= region.Bounds.NorthWest.Longitude &&
                NorthWest.Latitude >= region.Bounds.NorthWest.Latitude &&
                SouthEast.Longitude >= region.Bounds.SouthEast.Longitude &&
                SouthEast.Latitude <= region.Bounds.SouthEast.Latitude;
        }

        private GeoPoint GetCentroid()
        {
            return new GeoPoint(
                (NorthWest.Latitude + SouthEast.Latitude) / 2.0,
                (NorthWest.Longitude + SouthEast.Longitude) / 2.0);
        }

        public Area GetArea()
        {
            var width = NorthWest.GetDistance(NorthWest.Latitude, SouthEast.Longitude);
            var height = NorthWest.GetDistance(SouthEast.Latitude, NorthWest.Longitude);
            return new Area(width.Value * height.Value, UnitsOfLength.NauticalMile);
        }

        public override string ToString()
        {
            return String.Format($"[{NorthWest}, {SouthEast}]");
        }

        public Distance GetDistance(GeoPoint point, UnitsOfLength units = UnitsOfLength.NauticalMile)
        {
            throw new NotImplementedException();
        }

        public bool IsWithinRange(GeoPoint point, Distance range)
        {
            throw new NotImplementedException();
        }

        public Displacement GetDisplacement(GeoPoint point, UnitsOfLength units = UnitsOfLength.NauticalMile)
        {
            throw new NotImplementedException();
        }

        public IGeoRegion GetIntersection(IGeoRegion region)
        {
            throw new NotImplementedException();
        }

        public IGeoRegion GetUnion(IGeoRegion region)
        {
            throw new NotImplementedException();
        }

        public bool Intersects(IGeoRegion region)
        {
            throw new NotImplementedException();
        }
    }
}
