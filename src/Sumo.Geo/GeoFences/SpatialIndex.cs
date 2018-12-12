using Sumo.Geo.Geographies;
using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.Geo.GeoFences
{
    public class SpatialIndex
    {
        public SpatialIndex()
        {
            for (var lat = 180 - 1; lat >= 0; --lat)
            {
                for (var lon = 360 - 1; lon >= 0; --lon)
                {
                    _index[lat, lon] = new List<Geography>();
                }
            }
        }

        private readonly List<Geography>[,] _index = new List<Geography>[180, 360];

        public void Add(Geography geography)
        {
            var vMinimumLatitude = (int)Math.Floor(geography.Bounds.NorthWest.Latitude) + 90; // top
            var vMaximumLatitude = (int)Math.Floor(geography.Bounds.SouthEast.Latitude) + 90; // bottom

            var vMinimumLongitude = (int)Math.Floor(geography.Bounds.NorthWest.Longitude) + 180; // left
            var vMaximumLongitude = (int)Math.Floor(geography.Bounds.SouthEast.Longitude) + 180; // right

            // add the geography element to every index region for which there is a GeoBox overlapped
            for (var lat = vMinimumLatitude; lat <= vMaximumLatitude; ++lat)
            {
                for (var lon = vMinimumLongitude; lon <= vMaximumLongitude; ++lon)
                {
                    _index[lat, lon].Add(geography);
                }
            }
        }

        public List<Geography> FindNearby(double latitude, double longitude)
        {
            return _index[(int)Math.Floor(latitude) + 90, (int)Math.Floor(longitude) + 180];
        }

        public List<Geography> FindNearby(GeoPoint point) 
        {
            return FindNearby(point.Latitude, point.Longitude);
        }

        public List<Geography> FindNearby(GeoBox bounds)
        {
            var result = new List<Geography>();

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
            var nearbyRegions = FindNearby(point)
                .Where((g) => g is Region)
                .Select((g) => g as Region);

            var result = new List<Region>(nearbyRegions.Count());

            foreach (var region in nearbyRegions)
            {
                if (region.Contains(point))
                {
                    result.Add(region);
                }
            }

            return result;
        }
    }
}
