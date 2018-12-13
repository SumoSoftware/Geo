using Sumo.Geo.Geographies;
using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.Geo.GeoFences
{
    public class GeographyIndex: SpatialIndex
    {

        public List<IGeography> FindNearby(double latitude, double longitude)
        {
            return _index[(int)Math.Floor(latitude) + 90, (int)Math.Floor(longitude) + 180];
        }

        public List<IGeography> FindNearby(GeoPoint point) 
        {
            return FindNearby(point.Latitude, point.Longitude);
        }

        public List<IGeography> FindNearby(Box bounds)
        {
            var result = new List<IGeography>();

            var vMinimumLatitude = (int)Math.Floor(bounds.NorthWest.Latitude) + 90; // top
            var vMaximumLatitude = (int)Math.Floor(bounds.SouthEast.Latitude) + 90; // bottom

            var vMinimumLongitude = (int)Math.Floor(bounds.NorthWest.Longitude) + 180; // left
            var vMaximumLongitude = (int)Math.Floor(bounds.SouthEast.Longitude) + 180; // right

            for (var lat = vMinimumLatitude; lat <= vMaximumLatitude; ++lat)
            {
                for (var lon = vMinimumLongitude; lon <= vMaximumLongitude; ++lon)
                {
                    result.AddRange(_index[lat, lon]);
                }
            }

            return result;
        }
        
        public List<Geography> FindNearby(GeoPoint point, Distance range)
        {
            var nearbyGeographies = FindNearby(point);
            var result = new List<Geography>(nearbyGeographies.Count);
            foreach(var geography in nearbyGeographies)
            {
                //todo: add a method like WithinRange(GeoPoint point, Distance range) to Geography to be overriden by descendents
                throw new NotImplementedException();
            }
            return result;
        }

        public List<Region> FindRegions(GeoPoint point)
        {
            return FindNearby(point)
                .Where((g) => g is Region)
                .Select((g) => g as Region)
                .Where((r) => r.Contains(point))
                .ToList();
        }
    }
}
