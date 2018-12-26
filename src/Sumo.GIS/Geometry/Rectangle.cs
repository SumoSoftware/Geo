using Sumo.GIS.Metrics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.GIS.Geometry
{
    public partial class Rectangle : IPath, IShape
    {
        public Rectangle()
        {
            _points = new Point[] { new Point(), new Point(), new Point(), new Point() };
            _northWest = this[0];
            _southEast = this[2];
        }

        public Rectangle(Point northWest, Point southEast)
        {
            _points = new Point[4];
            NorthWest = northWest ?? throw new ArgumentNullException(nameof(northWest));
            SouthEast = southEast ?? throw new ArgumentNullException(nameof(southEast));
        }

        private Point[] _points;

        public Point this[int i]
        {
            get => _points[i];
            private set => _points[i] = value;
        }

        private Point _northWest;
        public Point NorthWest
        {
            get => _northWest;
            set
            {
                if (_northWest != value)
                {
                    _northWest = value;
                    this[0] = _northWest; // first item
                    this[4] = _northWest; // last item that closes the polygon
                    this[1] = (new Point(NorthWest.Latitude, SouthEast.Longitude));
                    this[3] = (new Point(SouthEast.Latitude, NorthWest.Longitude));
                }
            }
        }

        private Point _southEast;
        public Point SouthEast
        {
            get => _southEast;
            set
            {
                if (_southEast != value)
                {
                    _southEast = value;
                    this[2] = _southEast;
                    this[1] = (new Point(NorthWest.Latitude, SouthEast.Longitude));
                    this[3] = (new Point(SouthEast.Latitude, NorthWest.Longitude));
                }
            }
        }

        public Point Origin => this[0];

        public Point Terminus => this[0];

        public Area GetArea(UnitsOfLength units)
        {
            var width = NorthWest.GetDistance(NorthWest.Latitude, SouthEast.Longitude).ConvertTo(units);
            var height = NorthWest.GetDistance(SouthEast.Latitude, NorthWest.Longitude).ConvertTo(units);
            return new Area(width.Value * height.Value, units);
        }

        public Distance GetPerimeter(UnitsOfLength units)
        {
            var width = NorthWest.GetDistance(NorthWest.Latitude, SouthEast.Longitude).ConvertTo(units);
            var height = NorthWest.GetDistance(SouthEast.Latitude, NorthWest.Longitude).ConvertTo(units);
            return width * 2 + height * 2;
        }

        public Point GetCentroid()
        {
            var avgLatitude = _points.Sum((p) => p.Latitude) / 4;
            var avgLongitude = _points.Sum((p) => p.Longitude) / 4;
            var avgElevation = new Distance(_points.Sum((p) => p.Elevation.ConvertTo(UnitsOfLength.Meter).Value) / 4, UnitsOfLength.Meter);
            return new Point(avgLatitude, avgLongitude, avgElevation);
        }

        public Distance GetDistance(UnitsOfLength units)
        {
            return GetPerimeter(units);
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return (_points as IEnumerable<Point>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _points.GetEnumerator();
        }
    }
}
