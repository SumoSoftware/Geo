using Sumo.GIS.Metrics;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Sumo.GIS.Geometry
{
    public partial class LineSegment : IFigure, IPath
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

            _points = new Point[] { point1, point2 };
        }

        public LineSegment(double lat1, double lon1, double lat2, double lon2) : this(new Point(lat1, lon1), new Point(lat2, lon2))
        {
        }

        public LineSegment(LineSegment lineSegment) : this(lineSegment?._points[0], lineSegment?._points[1])
        {
        }

        private Point[] _points;
        public Point this[int i]
        {
            get => _points[i];
        }

        public Point Origin
        {
            get => _points[0];
            set => _points[0] = value;
        }

        public Point Terminus
        {
            get => _points[1];
            set => _points[1] = value;
        }

        /// <summary>
        /// returns geodesic distance (great arc)
        /// </summary>
        /// <returns></returns>
        public virtual Distance GetDistance(UnitsOfLength units)
        {
            return _points[0].GetDistance(_points[1], units);
        }

        public Angle Azimuth()
        {
            return _points[0].GetAzimuth(_points[1]);
        }

        public override string ToString()
        {
            return String.Format($"[{_points[0]}, {_points[1]}]");
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return (_points as IEnumerable<Point>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _points.GetEnumerator();
        }

        //protected override void SetBounds()
        //{
        //    NorthWest = new Point(Points.Max(p => p.Latitude), Points.Min(p => p.Longitude));
        //    SouthEast = new Point(Points.Min(p => p.Latitude), Points.Max(p => p.Longitude));
        //}
    }
}
