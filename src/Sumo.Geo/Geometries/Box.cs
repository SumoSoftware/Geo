using Sumo.Geo.Metrics;
using System;

namespace Sumo.Geo.Geometries
{
    public partial class Box : Polygon
    {
        public Box()
            : base(new Point[] { new Point(), new Point(), new Point(), new Point() })
        {
            _northWest = Coordinates[0];
            _southEast = Coordinates[2];
        }

        public Box(Point northWest, Point southEast)
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

        public override Area GetArea()
        {
            var width = NorthWest.GetDistance(NorthWest.Latitude, SouthEast.Longitude);
            var height = NorthWest.GetDistance(SouthEast.Latitude, NorthWest.Longitude);
            return new Area(width.Value * height.Value, UnitsOfLength.NauticalMile);
        }
    }
}
