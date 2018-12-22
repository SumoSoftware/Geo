using Sumo.GIS.Metrics;
using System;

namespace Sumo.GIS.GeometricFigures
{
    public partial class Point : IFigure
    {
        public Point()
        {
            Elevation = new Distance(0.0, UnitsOfLength.Foot);
        }

        public Point(double latitude, double longitude) : this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public Point(double latitude, double longitude, Distance elevation)
        {
            Latitude = latitude;
            Longitude = longitude;
            Elevation = new Distance(elevation);
        }

        public Point(Point point) : this(point.Latitude, point.Longitude, point.Elevation)
        {
        }

        private double _latitude;
        public double Latitude
        {
            get => _latitude;
            set
            {
                if (_latitude != value)
                {
                    _latitude = value;
                    if (_latitude > 90.0)
                    {
                        _latitude = 90.0;
                    }
                    else if (_latitude < -90.0)
                    {
                        _latitude = -90.0;
                    }
                }
            }
        }

        private double _longitude;
        public double Longitude
        {
            get => _longitude;
            set
            {
                if (_longitude != value)
                {
                    _longitude = value;
                    if (_longitude > 180.0)
                    {
                        _longitude = 180.0;
                    }
                    else if (_longitude < -180.0)
                    {
                        _longitude = -180.0;
                    }
                }
            }
        }

        public Distance Elevation { get; set; }

        private Distance GetDistance(double latitude1, double longitude1, double latitude2, double longitude2, UnitsOfLength units = UnitsOfLength.NauticalMile)
        {
            double phi_s = latitude1.ToRadians(),
               lamda_s = longitude1.ToRadians(),
               phi_f = latitude2.ToRadians(),
               lamda_f = longitude2.ToRadians();

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

        /// <summary>
        /// returns geodesic distance (great arc)
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Distance GetDistance(double latitude, double longitude, UnitsOfLength units = UnitsOfLength.NauticalMile)
        {
            return GetDistance(Latitude, Longitude, latitude, longitude, units);
        }

        /// <summary>
        /// returns geodesic distance (great arc)
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Distance GetDistance(Point point, UnitsOfLength units = UnitsOfLength.NauticalMile)
        {
            if (point == null)
            {
                throw new ArgumentNullException(nameof(point));
            }

            return GetDistance(point.Latitude, point.Longitude, units);
        }

        public Angle GetHeading(double latitude, double longitude)
        {
            var xDelta = GetDistance(Latitude, Longitude, latitude, Longitude, UnitsOfLength.NauticalMile);
            var yDelta = GetDistance(Latitude, Longitude, Latitude, longitude, UnitsOfLength.NauticalMile);
            var degrees = Math.Atan2(yDelta.Value, xDelta.Value).ToDegrees();
            return new Angle(degrees, UnitsOfAngle.Degree);
        }

        public Angle GetHeading(Point point)
        {
            if (point == null)
            {
                throw new ArgumentNullException(nameof(point));
            }

            return GetHeading(point.Latitude, point.Longitude);
        }

        public Displacement GetDisplacement(double latitude, double longitude, UnitsOfLength units = UnitsOfLength.NauticalMile)
        {
            return new Displacement(this, GetHeading(latitude, longitude), GetDistance(latitude, longitude, units));
        }

        public Displacement GetDisplacement(Point point, UnitsOfLength units = UnitsOfLength.NauticalMile)
        {
            if (point == null)
            {
                throw new ArgumentNullException(nameof(point));
            }

            return GetDisplacement(point.Latitude, point.Longitude, units);
        }

        public bool IsWithinRange(Point point, Distance range)
        {
            return GetDistance(point, range.Units) <= range;
        }

        public override string ToString()
        {
            if (Elevation.Value > 0.0)
            {
                return String.Format($"({Latitude.ToString("F5")}, {Longitude.ToString("F5")}, {Elevation.Value.ToString("F5")})");
            }
            return String.Format($"({Latitude.ToString("F5")}, {Longitude.ToString("F5")})");
        }
    }
}
