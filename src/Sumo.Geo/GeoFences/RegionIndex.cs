//using Sumo.Geo.Geographies;
//using Sumo.Geo.Metrics;
//using Sumo.Geo.Geometries;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Sumo.Geo.GeoFences
//{
//    public class RegionIndex: SpatialIndex
//    {
//        public void Add(IRegion region)
//        {
//            var minimumLatitude = (int)Math.Floor(region.NorthWest.Latitude) + 90; // top
//            var maximumLatitude = (int)Math.Floor(region.SouthEast.Latitude) + 90; // bottom

//            var minimumLongitude = (int)Math.Floor(region.NorthWest.Longitude) + 180; // left
//            var maximumLongitude = (int)Math.Floor(region.SouthEast.Longitude) + 180; // right

//            // add the geography element to every index region for which there is a GeoBox overlapped
//            for (var lat = minimumLatitude; lat <= maximumLatitude; ++lat)
//            {
//                for (var lon = minimumLongitude; lon <= maximumLongitude; ++lon)
//                {
//                    var page = _index[lat, lon];
//                    if (!page.Contains(region))
//                    {
//                        page.Add(region);
//                    }
//                }
//            }
//        }


//        public List<IGeography> FindNearby(double latitude, double longitude)
//        {
//            return _index[(int)Math.Floor(latitude) + 90, (int)Math.Floor(longitude) + 180];
//        }

//        public List<IGeography> FindNearby(Point point) 
//        {
//            return FindNearby(point.Latitude, point.Longitude);
//        }

//        public List<IGeography> FindNearby(Box bounds)
//        {
//            var result = new List<IGeography>();

//            var vMinimumLatitude = (int)Math.Floor(bounds.NorthWest.Latitude) + 90; // top
//            var vMaximumLatitude = (int)Math.Floor(bounds.SouthEast.Latitude) + 90; // bottom

//            var vMinimumLongitude = (int)Math.Floor(bounds.NorthWest.Longitude) + 180; // left
//            var vMaximumLongitude = (int)Math.Floor(bounds.SouthEast.Longitude) + 180; // right

//            for (var lat = vMinimumLatitude; lat <= vMaximumLatitude; ++lat)
//            {
//                for (var lon = vMinimumLongitude; lon <= vMaximumLongitude; ++lon)
//                {
//                    result.AddRange(_index[lat, lon]);
//                }
//            }

//            return result;
//        }
        
//        public List<Geography> FindNearby(Point point, Distance range)
//        {
//            var nearbyGeographies = FindNearby(point);
//            var result = new List<Geography>(nearbyGeographies.Count);
//            foreach(var geography in nearbyGeographies)
//            {
//                //todo: add a method like WithinRange(GeoPoint point, Distance range) to Geography to be overriden by descendents
//                throw new NotImplementedException();
//            }
//            return result;
//        }

//        public List<Region> FindRegions(Point point)
//        {
//            return FindNearby(point)
//                .Where((g) => g is Region)
//                .Select((g) => g as Region)
//                .Where((r) => r.Contains(point))
//                .ToList();
//        }
//    }
//}
