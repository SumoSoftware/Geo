using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;
using System;

namespace Sumo.Geo.Geographies
{
    public abstract class Region : Geography, IGeoRegion
    {
        #region bounds
        private GeoPoint _northWest;
        public GeoPoint NorthWest
        {
            get
            {
                if (_northWest == null)
                {
                    SetBounds();
                }

                return _northWest;
            }
            protected set => _northWest = value;
        }

        private GeoPoint _southEast;
        public GeoPoint SouthEast
        {
            get
            {
                if (_southEast == null)
                {
                    SetBounds();
                }

                return _southEast;
            }
            protected set => _southEast = value;
        }

        protected virtual void SetBounds() { }
        #endregion

        #region centroid
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

        protected virtual GeoPoint GetCentroid()
        {
            return new GeoPoint(
                (NorthWest.Latitude + SouthEast.Latitude) / 2.0,
                (NorthWest.Longitude + SouthEast.Longitude) / 2.0);
        }
        #endregion

        #region contains
        /// <summary>
        /// returns true if the point is precisly within the region
        /// checks near first to bypass complex logic
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Contains(GeoPoint point, GeoPositionPrecision precision = GeoPositionPrecision.High)
        {
            // just check the bouding box for low precision
            var result =
                point.Latitude <= NorthWest.Latitude &&
                point.Latitude >= SouthEast.Latitude &&
                point.Longitude >= NorthWest.Longitude &&
                point.Longitude <= SouthEast.Longitude;

            return precision == GeoPositionPrecision.Low
                ? result
                : result && PrecisionContains(point);
        }

        /// <summary>
        /// uses optimized logic to perform complex geodetic algorithms
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        protected virtual bool PrecisionContains(GeoPoint point)
        {
            return true;
        }

        public bool Contains(IGeoRegion region, GeoPositionPrecision precision = GeoPositionPrecision.High)
        {
            // just check the bouding box for low precision
            var result =
                NorthWest.Longitude <= region.NorthWest.Longitude &&
                NorthWest.Latitude >= region.NorthWest.Latitude &&
                SouthEast.Longitude >= region.SouthEast.Longitude &&
                SouthEast.Latitude <= region.SouthEast.Latitude;

            return precision == GeoPositionPrecision.Low
                ? result
                : result && PrecisionContains(region);
        }

        /// <summary>
        /// uses optimized logic to perform complex geodetic algorithms
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        protected virtual bool PrecisionContains(IGeoRegion region)
        {
            return true;
        }
        #endregion

        public virtual Area GetArea()
        {
            var width = NorthWest.GetDistance(NorthWest.Latitude, SouthEast.Longitude);
            var height = NorthWest.GetDistance(SouthEast.Latitude, NorthWest.Longitude);
            return new Area(width.Value * height.Value, UnitsOfLength.NauticalMile);
        }

        public virtual bool Intersects(IGeoRegion region)
        {
            throw new NotImplementedException();
        }

        public virtual IGeoRegion GetIntersection(IGeoRegion region)
        {
            throw new NotImplementedException();
        }

        public virtual IGeoRegion GetUnion(IGeoRegion region)
        {
            throw new NotImplementedException();
        }

        public override Distance GetDistance(GeoPoint point, UnitsOfLength units = UnitsOfLength.NauticalMile)
        {
            throw new NotImplementedException();
        }

        public override bool IsWithinRange(GeoPoint point, Distance range)
        {
            throw new NotImplementedException();
        }

        public override Displacement GetDisplacement(GeoPoint point, UnitsOfLength units = UnitsOfLength.NauticalMile)
        {
            throw new NotImplementedException();
        }
    }
}
