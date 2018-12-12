using Sumo.Geo.Geographies;
using Sumo.Geo.Primitives;
using System;

namespace Sumo.Geo.Evaluators
{
    public abstract class RegionEvaluator : IRegionEvaluator
    {
        public RegionEvaluator(Region region)
        {
            Region = region ?? throw new ArgumentNullException(nameof(region));
        }

        protected Region Region { get; }
        protected Rectangle Bounds { get; set; }

        public bool Contains(GeoPoint point)
        {
            if (Bounds.Contains(point))
            {
                return PrecisionContains(point);
            }
            return false;
        }

        protected abstract bool PrecisionContains(GeoPoint point);
    }
}
