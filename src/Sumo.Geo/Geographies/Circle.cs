using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;
using System;

namespace Sumo.Geo.Geographies
{
    public partial class Circle : Region
    {
        public Circle() { }

        public Circle(GeoPoint center, Distance radius)
        {
            Center = center ?? throw new ArgumentNullException(nameof(center));
            Radius = radius ?? throw new ArgumentNullException(nameof(radius));
        }

        private double _radiusInNauticalMiles;

        public GeoPoint Center { get; set; }

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

        public override GeoPoint GetCentroid()
        {
            return Center;
        }

        protected override GeoBox GetBounds()
        {
            var degreesLatitude = Geography.DegreesLatitudePerNauticalMile * _radiusInNauticalMiles;
            var degressLongitude = Geography.GetDegreesLongitudePerNauticalMile(Center.Latitude) * _radiusInNauticalMiles;

            return new GeoBox(
                new GeoPoint(Center.Latitude + degreesLatitude, Center.Longitude - degressLongitude),
                new GeoPoint(Center.Latitude - degreesLatitude, Center.Longitude + degressLongitude));
        }

        protected override bool PrecisionContains(GeoPoint point)
        {
            throw new System.NotImplementedException();
        }
    }
}
