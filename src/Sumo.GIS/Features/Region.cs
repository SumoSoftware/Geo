//using Sumo.GIS.Metrics;
//using Sumo.GIS.Geometries;
//using System;

//namespace Sumo.GIS.Features
//{
//    public abstract class Region : Geography, IRegion
//    {


//        #region centroid
//        private Point _centroid;
//        public Point Centroid
//        {
//            get
//            {
//                if (_centroid == null)
//                {
//                    _centroid = GetCentroid();
//                }

//                return _centroid;
//            }
//        }

//        protected virtual Point GetCentroid()
//        {
//            return new Point(
//                (NorthWest.Latitude + SouthEast.Latitude) / 2.0,
//                (NorthWest.Longitude + SouthEast.Longitude) / 2.0);
//        }
//        #endregion

//        #region contains
//        /// <summary>
//        /// returns true if the point is precisly within the region
//        /// checks near first to bypass complex logic
//        /// </summary>
//        /// <param name="point"></param>
//        /// <returns></returns>
//        public bool Contains(Point point, GeoPositionPrecision precision = GeoPositionPrecision.High)
//        {
//            // just check the bouding box for low precision
//            var result =
//                point.Latitude <= NorthWest.Latitude &&
//                point.Latitude >= SouthEast.Latitude &&
//                point.Longitude >= NorthWest.Longitude &&
//                point.Longitude <= SouthEast.Longitude;

//            return precision == GeoPositionPrecision.Low
//                ? result
//                : result && PrecisionContains(point);
//        }

//        /// <summary>
//        /// uses optimized logic to perform complex geodetic algorithms
//        /// </summary>
//        /// <param name="point"></param>
//        /// <returns></returns>
//        protected virtual bool PrecisionContains(Point point)
//        {
//            return true;
//        }

//        public bool Contains(IRegion region, GeoPositionPrecision precision = GeoPositionPrecision.High)
//        {
//            // just check the bouding box for low precision
//            var result =
//                NorthWest.Longitude <= region.NorthWest.Longitude &&
//                NorthWest.Latitude >= region.NorthWest.Latitude &&
//                SouthEast.Longitude >= region.SouthEast.Longitude &&
//                SouthEast.Latitude <= region.SouthEast.Latitude;

//            return precision == GeoPositionPrecision.Low
//                ? result
//                : result && PrecisionContains(region);
//        }

//        /// <summary>
//        /// uses optimized logic to perform complex geodetic algorithms
//        /// </summary>
//        /// <param name="point"></param>
//        /// <returns></returns>
//        protected virtual bool PrecisionContains(IRegion region)
//        {
//            return true;
//        }
//        #endregion

//        public virtual Area GetArea()
//        {
//            var width = NorthWest.GetDistance(NorthWest.Latitude, SouthEast.Longitude);
//            var height = NorthWest.GetDistance(SouthEast.Latitude, NorthWest.Longitude);
//            return new Area(width.Value * height.Value, UnitsOfLength.NauticalMile);
//        }

//        public virtual bool Intersects(IRegion region)
//        {
//            throw new NotImplementedException();
//        }

//        public virtual IRegion GetIntersection(IRegion region)
//        {
//            throw new NotImplementedException();
//        }

//        public virtual IRegion GetUnion(IRegion region)
//        {
//            throw new NotImplementedException();
//        }

//        public override Distance GetDistance(Point point, UnitsOfLength units = UnitsOfLength.NauticalMile)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool IsWithinRange(Point point, Distance range)
//        {
//            throw new NotImplementedException();
//        }

//        public override Displacement GetDisplacement(Point point, UnitsOfLength units = UnitsOfLength.NauticalMile)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
