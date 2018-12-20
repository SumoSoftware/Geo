//using Sumo.Geo.Metrics;
//using Sumo.Geo.Geometries;
//using System;

////todo: consider exporting geographies to kml

//namespace Sumo.Geo.Features
//{
//    public abstract class Geography : IGeography
//    {
//        // assume NM is equal to one minute of a degree.
//        public const double DegreesLatitudePerNauticalMile = (1.0 / 60.0);

//        public static double GetDegreesLongitudePerNauticalMile(double latitude)
//        {
//            double upperLat = 90.0, lowerN = 6398.15, upperN = 6399.59, averageN;
//            var absoluteLatitude = Math.Abs(latitude);

//            // Formula is as follows:
//            //   PI / 180 * COS (0) N (0) where N(0) is constant based on latitude

//            // we need to figure out the upper and lower bounds for N
//            if (absoluteLatitude <= 15.0)
//            {
//                upperLat = 15.0;
//                lowerN = 6378.14;
//                upperN = 6379.57;
//            }
//            else if (absoluteLatitude <= 30.0)
//            {
//                upperLat = 30.0;
//                lowerN = 6379.57;
//                upperN = 6383.48;
//            }
//            else if (absoluteLatitude <= 45.0)
//            {
//                upperLat = 45.0;
//                lowerN = 6383.48;
//                upperN = 6388.84;
//            }
//            else if (absoluteLatitude <= 60.0)
//            {
//                upperLat = 60.0;
//                lowerN = 6388.84;
//                upperN = 6394.21;
//            }
//            else if (absoluteLatitude <= 75.0)
//            {
//                upperLat = 75.0;
//                lowerN = 6394.21;
//                upperN = 6398.15;
//            }

//            // next, let's get an approximate average between known upper
//            // and lower values for N... not 100% exact but close
//            averageN = lowerN + (((upperLat - absoluteLatitude) / 15) * (upperN - lowerN));

//            // finally plug into equation to return degrees per NM.
//            return (1 / (((Math.PI / 180) * Math.Cos(latitude.ToRadians()) * averageN) / 1.853));


//            //public static double DegreeLongPerNMAtLat(double lat)
//            //{
//            //    double latitudeRadians = Radians(lat);
//            //    double p1 = 111412.84;
//            //    double p2 = -93.5;
//            //    double p3 = 0.118;
//            //    double longLength = (p1 * Math.Cos(latitudeRadians)) + (p2 * Math.Cos(3 * latitudeRadians)) + (p3 * Math.Cos(5 * latitudeRadians));
//            //    double nm = longLength * 3.280833333 / (5280 / 0.86898);
//            //    return 1 / nm;
//            //}

//        }

//        public abstract Displacement GetDisplacement(Point point, UnitsOfLength units = UnitsOfLength.NauticalMile);

//        public abstract Distance GetDistance(Point point, UnitsOfLength units = UnitsOfLength.NauticalMile);

//        public abstract bool IsWithinRange(Point point, Distance range);
//    }
//}
