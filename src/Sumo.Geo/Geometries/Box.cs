﻿using System;

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
                    Coordinates[0] = _northWest; // first item
                    Coordinates[4] = _northWest; // last item that closes the polygon
                    Coordinates[1] = (new Point(NorthWest.Latitude, SouthEast.Longitude));
                    Coordinates[3] = (new Point(SouthEast.Latitude, NorthWest.Longitude));
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
                    Coordinates[2] = _southEast;
                    Coordinates[1] = (new Point(NorthWest.Latitude, SouthEast.Longitude));
                    Coordinates[3] = (new Point(SouthEast.Latitude, NorthWest.Longitude));
                }
            }
        }
    }
}