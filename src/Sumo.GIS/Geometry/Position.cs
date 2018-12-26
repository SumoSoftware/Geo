using Sumo.GIS.Metrics;
using System;
using System.Collections.Generic;

namespace Sumo.GIS.Geometry
{
    public partial class Position : Point, IEquatable<Position>
    {
        public Position()
        {
            Elevation = new Distance(0.0, UnitsOfLength.Foot);
        }

        public Position(Point point) : base(point)
        {
            Elevation = new Distance(0.0, UnitsOfLength.Foot);
        }

        public Position(double latitude, double longitude) : base(latitude, longitude)
        {
            Elevation = new Distance(0.0, UnitsOfLength.Foot);
        }

        public Position(double latitude, double longitude, Distance elevation) : base(latitude, longitude)
        {
            Elevation = new Distance(elevation);
        }

        public Position(Position position) : base(position)
        {
            Elevation = new Distance(position.Elevation);
        }

        public Distance Elevation { get; set; }

        public override string ToString()
        {
            if (Elevation.Value > 0.0)
            {
                return String.Format($"({Latitude.ToString("F5")}, {Longitude.ToString("F5")}, {Elevation.Value.ToString("F5")})");
            }
            return base.ToString();
        }
    }
}
