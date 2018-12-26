using Sumo.GIS.Metrics;
using System;

namespace Sumo.GIS.Geometry
{
    public class Arc : LineSegment, IFigure, IPath, IShape
    {
        public enum ArcTypes
        {
            Minor, //subtends < 180 degrees
            Major // subtends > 180 degrees
        }

        public Arc()
        {
            Center = new Point();
            Radius = new Distance();
        }

        public Arc(Point center, Distance radius, ArcTypes type, LineSegment lineSegment) : base(lineSegment)
        {
            Center = center ?? throw new ArgumentNullException(nameof(center));
            Radius = radius ?? throw new ArgumentNullException(nameof(radius));
            Type = type;
        }

        public Arc(Point center, Distance radius, ArcTypes type, Point point1, Point point2) : base(point1, point2)
        {
            Center = center ?? throw new ArgumentNullException(nameof(center));
            Radius = radius ?? throw new ArgumentNullException(nameof(radius));
            Type = type;
        }

        public Arc(Point center, Distance radius, ArcTypes type, double lat1, double lon1, double lat2, double lon2) : base(lat1, lon1, lat2, lon2)
        {
            Center = center ?? throw new ArgumentNullException(nameof(center));
            Radius = radius ?? throw new ArgumentNullException(nameof(radius));
            Type = type;
        }

        public Point Center { get; set; }
        public Distance Radius { get; set; }
        public ArcTypes Type { get; set; }

        public override Distance GetDistance(UnitsOfLength units)
        {
            var degrees = GetAngle(UnitsOfAngle.Degree).Value;
            return new Distance(new Circle(Center, Radius).GetPerimeter(units).Value * (degrees / 360), units);
        }

        public Angle GetAngle(UnitsOfAngle units)
        {
            var degrees = Math.Abs((Center.GetAzimuth(Origin, UnitsOfAngle.Degree) - Center.GetAzimuth(Terminus, UnitsOfAngle.Degree)).Value);
            if ((Type == ArcTypes.Minor && degrees > 180) || (Type == ArcTypes.Major && degrees < 180))
            {
                degrees = 360 - degrees;
            }
            return new Angle(degrees, UnitsOfAngle.Degree).ConvertTo(units);            
        }

        public Area GetArea(UnitsOfLength units)
        {
            var degrees = GetAngle(UnitsOfAngle.Degree).Value;
            return new Area(new Circle(Center, Radius).GetArea(units).Value * (degrees / 360), units);
        }

        public Point GetCentroid()
        {
            return Center;
        }

        public Distance GetPerimeter(UnitsOfLength units)
        {
            return GetDistance(units);
        }
    }
}
