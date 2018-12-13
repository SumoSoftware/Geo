using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;
using System;

namespace Sumo.Geo.Geographies
{
    public abstract class Region : Geography
    {
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
            return Bounds.GetArea();
        }
    }
}
