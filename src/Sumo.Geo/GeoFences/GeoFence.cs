//using Sumo.Geo.Features;
//using Sumo.Geo.Geometries;
//using System.Collections.Generic;
//using System.Linq;

//namespace Sumo.Geo.GeoFences
//{
//    //todo: add state managmer for geofences - maybe that's a new library - Sumo.Geo.Iot

//    public partial class GeoFence : Region
//    {
//        public List<Region> Regions { get; set; }

//        protected override Box GetBounds()
//        {
//            return new Box(
//                new Point(Regions.Max(r => r.Bounds.NorthWest.Latitude), Regions.Min(r => r.Bounds.NorthWest.Longitude)),
//                new Point(Regions.Min(r => r.Bounds.SouthEast.Latitude), Regions.Max(r => r.Bounds.SouthEast.Longitude)));
//        }

//        protected override bool PrecisionContains(Point point)
//        {
//            foreach (var region in Regions)
//            {
//                if (region.Contains(point))
//                {
//                    return true;
//                }
//            }
//            return false;
//        }
//    }
//}
