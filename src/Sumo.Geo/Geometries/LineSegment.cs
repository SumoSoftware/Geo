using Sumo.Geo.Metrics;
using System;

namespace Sumo.Geo.Geometries
{
    public partial class LineSegment : IGeometry
    {
        public LineSegment()
        {
            Coordinates = new Point[2];
        }

        public LineSegment(Point point1, Point point2)
        {
            if (point1 == null)
            {
                throw new ArgumentNullException(nameof(point1));
            }

            if (point2 == null)
            {
                throw new ArgumentNullException(nameof(point2));
            }

            Coordinates = new Point[] { point1, point2 };
        }

        public LineSegment(double lat1, double lon1, double lat2, double lon2) : this(new Point(lat1, lon1), new Point(lat2, lon2))
        {
        }

        public LineSegment(LineSegment lineSegment) : this(lineSegment?.Coordinates[0], lineSegment?.Coordinates[1])
        {
        }

        public Point[] Coordinates { get; }

        /// <summary>
        /// returns geodesic distance (great arc)
        /// </summary>
        /// <returns></returns>
        public Distance GetGeoDesicLength(UnitsOfLength units = UnitsOfLength.NauticalMile)
        {
            return Coordinates[0].GetDistance(Coordinates[1], units);
        }

        public Angle GetHeading()
        {
            return Coordinates[0].GetHeading(Coordinates[1]);
        }

        public override string ToString()
        {
            return String.Format($"[{Coordinates[0]}, {Coordinates[1]}]");
        }

        //protected override void SetBounds()
        //{
        //    NorthWest = new Point(Points.Max(p => p.Latitude), Points.Min(p => p.Longitude));
        //    SouthEast = new Point(Points.Min(p => p.Latitude), Points.Max(p => p.Longitude));
        //}
    }
}
