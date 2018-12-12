using Sumo.Geo.Geographies;
using Sumo.Geo.Primitives;
using System.Collections.Generic;

namespace Sumo.Geo.GeoFences
{
    public partial class GeoFence
    {
        public List<Region> Regions { get; set; }

        public bool Contains(GeoPoint point)
        {
            foreach (var region in Regions)
            {
                if (region.Contains(point))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
