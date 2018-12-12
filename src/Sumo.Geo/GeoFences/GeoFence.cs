using Sumo.Geo.Geographies;
using Sumo.Geo.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.Geo.GeoFences
{
    public partial class GeoFence : Region
    {
        public List<Region> Regions { get; set; }

        protected override GeoBox GetBounds()
        {
            return new GeoBox(
                new GeoPoint(Regions.Max(r => r.Bounds.NorthWest.Latitude), Regions.Min(r => r.Bounds.NorthWest.Longitude)),
                new GeoPoint(Regions.Min(r => r.Bounds.SouthEast.Latitude), Regions.Max(r => r.Bounds.SouthEast.Longitude)));
        }

        protected override bool PrecisionContains(GeoPoint point)
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
