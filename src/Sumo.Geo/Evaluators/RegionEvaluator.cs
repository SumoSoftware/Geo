using Sumo.Geo.Geographies;
using Sumo.Geo.Primitives;
using System;

namespace Sumo.Geo.Evaluators
{
    //todo: aim to remove the concept of optimized evaluators
    // it should be possible to run the optimization process once per region, or on region changes
    // then store the optimized structure for fast loading and scanning
    public abstract class RegionEvaluator : IRegionEvaluator
    {
        public RegionEvaluator(Region region)
        {
            Region = region ?? throw new ArgumentNullException(nameof(region));
        }

        protected Region Region { get; }
        protected GeoBox Bounds { get; set; }

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
