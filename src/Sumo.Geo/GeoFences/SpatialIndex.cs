using Sumo.Geo.Primitives;
using System;
using System.Collections.Generic;

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
                    _index[lat, lon] = new List<IGeography>();
                }
            }
        }

        protected readonly List<IGeography>[,] _index = new List<IGeography>[180, 360];

        public void Add(GeoPoint point)
        {
            var lat = (int)Math.Floor(point.Latitude) + 90; // top
            var lon = (int)Math.Floor(point.Longitude) + 90; // bottom
            var page = _index[lat, lon];
            if (!page.Contains(point))
            {
                page.Add(point);
            }
        }

        public void Add(IRegion region)
        {
            var minimumLatitude = (int)Math.Floor(region.NorthWest.Latitude) + 90; // top
            var maximumLatitude = (int)Math.Floor(region.SouthEast.Latitude) + 90; // bottom

            var minimumLongitude = (int)Math.Floor(region.NorthWest.Longitude) + 180; // left
            var maximumLongitude = (int)Math.Floor(region.SouthEast.Longitude) + 180; // right

            // add the geography element to every index region for which there is a GeoBox overlapped
            for (var lat = minimumLatitude; lat <= maximumLatitude; ++lat)
            {
                for (var lon = minimumLongitude; lon <= maximumLongitude; ++lon)
                {
                    var page = _index[lat, lon];
                    if (!page.Contains(region))
                    {
                        page.Add(region);
                    }
                }
            }
        }
    }
}
