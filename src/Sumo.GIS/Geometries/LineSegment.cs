using Sumo.GIS.Metrics;
using System;

namespace Sumo.GIS.Geometries
{
    public partial class LineSegment : IGeometry
    {
        public LineSegment() : this(new Point(), new Point())
        {
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

            _coordinates = new Point[] { point1, point2 };
        }

        public LineSegment(double lat1, double lon1, double lat2, double lon2) : this(new Point(lat1, lon1), new Point(lat2, lon2))
        {
        }

        public LineSegment(LineSegment lineSegment) : this(lineSegment?._coordinates[0], lineSegment?._coordinates[1])
        {
        }

        private Point[] _coordinates;
        public Point this[int i]
        {
            get => _coordinates[i];
        }

        public Point Origin
        {
            get => _coordinates[0];
            set => _coordinates[0] = value;
        }

        public Point Terminus
        {
            get => _coordinates[1];
            set => _coordinates[1] = value;
        }

        /// <summary>
        /// returns geodesic distance (great arc)
        /// </summary>
        /// <returns></returns>
        public Distance GetLength(UnitsOfLength units = UnitsOfLength.NauticalMile)
        {
            return _coordinates[0].GetDistance(_coordinates[1], units);
        }

        public Angle GetHeading()
        {
            return _coordinates[0].GetHeading(_coordinates[1]);
        }

        public override string ToString()
        {
            return String.Format($"[{_coordinates[0]}, {_coordinates[1]}]");
        }

        //protected override void SetBounds()
        //{
        //    NorthWest = new Point(Points.Max(p => p.Latitude), Points.Min(p => p.Longitude));
        //    SouthEast = new Point(Points.Min(p => p.Latitude), Points.Max(p => p.Longitude));
        //}
    }
}
