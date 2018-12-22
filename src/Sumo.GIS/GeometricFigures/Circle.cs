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

        public Area GetArea()
        {
            // pi r^2
            var area = Math.PI * Math.Pow(Radius.Value, 2);
            return new Area(area, Radius.Units);
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
