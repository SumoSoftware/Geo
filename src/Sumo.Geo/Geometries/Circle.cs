using Sumo.Geo.Metrics;
using System;

namespace Sumo.Geo.Geometries
{
    public partial class Circle : IGeometry
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

        //protected override Point GetCentroid()
        //{
        //    return Center;
        //}

        //protected override void SetBounds()
        //{
        //    var degreesLatitude = Geography.DegreesLatitudePerNauticalMile * _radiusInNauticalMiles;
        //    var degressLongitude = Geography.GetDegreesLongitudePerNauticalMile(Center.Latitude) * _radiusInNauticalMiles;

        //    NorthWest = new Point(Center.Latitude + degreesLatitude, Center.Longitude - degressLongitude);
        //    SouthEast = new Point(Center.Latitude - degreesLatitude, Center.Longitude + degressLongitude);
        //}

        //protected override bool PrecisionContains(Point point)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override Area GetArea()
        //{
        //    // pi r^2
        //    var area = Math.PI * Math.Pow(Radius.Value, 2);
        //    return new Area(area, Radius.Units);
        //}
    }
}
