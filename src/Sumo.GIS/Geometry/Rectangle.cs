using Sumo.GIS.Metrics;
using System;

namespace Sumo.GIS.Geometry
{
    public partial class Rectangle : Polygon
    {
        public Rectangle()
            : base(new Point[] { new Point(), new Point(), new Point(), new Point() })
        {
            _northWest = this[0];
            _southEast = this[2];
        }

        public Rectangle(Point northWest, Point southEast)
            : base(new Point[] { northWest, new Point(northWest.Latitude, southEast.Longitude), southEast, new Point(southEast.Latitude, northWest.Longitude) })
        {
            _northWest = northWest ?? throw new ArgumentNullException(nameof(northWest));
            _southEast = southEast ?? throw new ArgumentNullException(nameof(southEast));
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

        public override Area GetArea(UnitsOfLength units)
        {
            var width = NorthWest.GetDistance(NorthWest.Latitude, SouthEast.Longitude).ConvertTo(units);
            var height = NorthWest.GetDistance(SouthEast.Latitude, NorthWest.Longitude).ConvertTo(units);
            return new Area(width.Value * height.Value, units);
        }
    }
}
