using Sumo.GIS.Metrics;
using System;

namespace Sumo.GIS.GeometricFigures
{
    public partial class Circle : IShape
    {
        public Circle() { }

        public Circle(Point center, Distance radius)
        {
            Center = center ?? throw new ArgumentNullException(nameof(center));
            Radius = radius ?? throw new ArgumentNullException(nameof(radius));
        }

        public Point Center { get; set; }

        private double _radiusInNauticalMiles;
        private Distance _radius;
        public Distance Radius
        {
            get => _radius;
            set
            {
                _radius = value;
                _radiusInNauticalMiles = Radius.ConvertTo(UnitsOfLength.NauticalMile).Value;
            }
        }

        public Area GetArea(UnitsOfLength units)
        {
            var area = Math.PI * Math.Pow(Radius.ConvertTo(units).Value, 2);
            return new Area(area, units);
        }

        public Distance GetPerimeter()
        {
            return GetCircumference();
        }

        public Distance GetCircumference()
        {
            return new Distance(2 * Math.PI * Radius.Value, Radius.Units);
        }

        public Point GetCentroid()
        {
            return Center;
        }

        //protected override void SetBounds()
        //{
        //    var degreesLatitude = Geography.DegreesLatitudePerNauticalMile * _radiusInNauticalMiles;
        //    var degressLongitude = Geography.GetDegreesLongitudePerNauticalMile(Center.Latitude) * _radiusInNauticalMiles;
        //    NorthWest = new Point(Center.Latitude + degreesLatitude, Center.Longitude - degressLongitude);
        //    SouthEast = new Point(Center.Latitude - degreesLatitude, Center.Longitude + degressLongitude);
        //}
    }
}
