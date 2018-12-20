//using Sumo.GIS.Geometries;
//using System;
//using System.Collections.Generic;

//namespace Sumo.GIS.GeoFences
//{
//    public class SpatialIndex
//    {
//        public SpatialIndex()
//        {
//            for (var lat = 180 - 1; lat >= 0; --lat)
//            {
//                for (var lon = 360 - 1; lon >= 0; --lon)
//                {
//                    _index[lat, lon] = new List<IGeography>();
//                }
//            }
//        }

//        protected readonly List<IGeography>[,] _index = new List<IGeography>[180, 360];

//        protected bool Add(IGeography geography, List<IGeography> page)
//        {
//            if (!page.Contains(geography))
//            {
//                page.Add(geography);
//                return true;
//            }
//            return false;
//        }
//    }
//}
