using Sumo.Geo.Metrics;
using System;

//todo: all primitives should be serializable for storage in mongo, docdb, json or xml files

namespace Sumo.Geo.Primitives
{
    public partial class GeoPoint
    {
        public GeoPoint() { }

        public GeoPoint(double latitude, double longitude, Distance elevation = null)
        {
            Latitude = latitude;
            Longitude = longitude;
            if (elevation != null)
            {
                Elevation = new Distance(elevation);
            }
        }

        public GeoPoint(GeoPoint point) : this(point.Latitude, point.Longitude, point.Elevation)
        {
        }

        //todo: add validation
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Distance Elevation { get; set; }

        /// <summary>
        /// returns geodesic distance (great arc)
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Distance GetDistance(GeoPoint point, UnitsOfLength units = UnitsOfLength.NauticalMile)
        {
            double phi_s = Latitude.ToRadians(),
                   lamda_s = Longitude.ToRadians(),
                   phi_f = point.Latitude.ToRadians(),
                   lamda_f = point.Longitude.ToRadians();

            // Vincenty formula
            var y =
                Math.Sqrt(Math.Pow((Math.Cos(phi_f) * Math.Sin(lamda_s - lamda_f)), 2) +
                Math.Pow((Math.Cos(phi_s) * Math.Sin(phi_f) - Math.Sin(phi_s) * Math.Cos(phi_f) * Math.Cos(lamda_s - lamda_f)), 2));
            var x = Math.Sin(phi_s) * Math.Sin(phi_f) + Math.Cos(phi_s) * Math.Cos(phi_f) * Math.Cos(lamda_s - lamda_f);
            var delta = Math.Atan2(y, x);
            var result = new Distance(delta.ToDegrees() * 60, UnitsOfLength.NauticalMile);

            if (units != UnitsOfLength.NauticalMile)
            {
                result = result.ConvertTo(units);
            }
            return result;

            //Vincenty formula
            //phi_s = latitude_s
            //lamda_s = longitude_s
            //phi_f = latitude_f
            //lamda_f = longitude_f

            //atan2(
            //sqrt(
            //(cos(phi_f)*sin(lamda_s-lamda_f))^2 + (cos(phi_s)*sin(phi_f)-sin(phi_s)*cos(phi_f)*cos(lamda_s-lamda_f))^2
            //)
            //,
            //(sin(phi_s)*sin(phi_f) + cos(phi_s)*cos(phi_f)*cos(lamda_s-lamda_f))
            //)

            //Haversine formula
            //dlon = lon2 - lon1
            //dlat = lat2 - lat1
            //a = sin^2(dlat/2) + cos(lat1) * cos(lat2) * sin^2(dlon/2)
            //c = 2 * arcsin(min(1,sqrt(a)))
            //d = R * c
        }

        public override string ToString()
        {
            if (Elevation != null)
            {
                return String.Format($"({Latitude.ToString("F5")}, {Longitude.ToString("F5")}, {Elevation.Value.ToString("F5")})");
            }
            return String.Format($"({Latitude.ToString("F5")}, {Longitude.ToString("F5")})");
        }
    }
}
