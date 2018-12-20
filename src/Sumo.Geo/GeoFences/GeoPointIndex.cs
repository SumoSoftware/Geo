//using Sumo.Geo.Geometries;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Sumo.Geo.GeoFences
//{
//    public class GeoPointIndex: SpatialIndex
//    {
//        public bool Add(Point point)
//        {
//            var lat = (int)Math.Floor(point.Latitude) + 90; // top
//            var lon = (int)Math.Floor(point.Longitude) + 90; // bottom
//            return Add(point, _index[lat, lon]);
//        }
//    }
//}
