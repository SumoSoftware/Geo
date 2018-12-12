using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;
using System;

namespace Sumo.Geo.Geographies
{
    public abstract class Region : Geography
    {
        private GeoBox _bounds;
        public GeoBox Bounds
        {
            get
            {
                if (_bounds == null)
                {
                    _bounds = GetBounds();
                }
                return _bounds;
            }
            set => _bounds = value;
        }

        /// <summary>
        /// calculates the bounding box of the region
        /// </summary>
        /// <returns></returns>
        protected abstract GeoBox GetBounds();

        /// <summary>
        /// calculates the centroid point of the region
        /// </summary>
        /// <returns></returns>
        public abstract GeoPoint GetCentroid();

        /// <summary>
        /// returns true of the point is within the bounding box of the region
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool IsNear(GeoPoint point)
        {
            return Bounds.Contains(point);
        }

        /// <summary>
        /// returns true if the point is precisly within the region
        /// checks near first to bypass complex logic
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Contains(GeoPoint point)
        {
            if (IsNear(point))
            {
                return PrecisionContains(point);
            }
            return false;
        }

        /// <summary>
        /// uses optimized logic to perform complex geodetic algorithms
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        protected abstract bool PrecisionContains(GeoPoint point);

        public virtual Region Union(Region geography)
        {
            throw new NotImplementedException();
        }

        public virtual Region Intersect(Region geography)
        {
            throw new NotImplementedException();
        }

        public virtual Area GetArea()
        {
            throw new NotImplementedException();
        }


    }
}
