using Sumo.Geo.Geographies;
using Sumo.Geo.Primitives;
using System;

namespace Sumo.Geo.Evaluators
{
    public class CircleEvaluator : GeographyEvaluator
    {
        public CircleEvaluator(Circle circle) : base(circle)
        {
            _radiusInNauticalMiles = circle.Radius.ConvertTo(Metrics.UnitsOfMeasure.NauticalMile).Value;

            var degreesLatitude = Geography.DegreesLatitudePerNauticalMile * _radiusInNauticalMiles;
            var degressLongitude = Geography.GetDegreesLongitudePerNauticalMile(circle.Center.Latitude) * _radiusInNauticalMiles;

            Bounds = new Rectangle(
                new Point(circle.Center.Latitude + degreesLatitude, circle.Center.Longitude - degressLongitude),
                new Point(circle.Center.Latitude - degreesLatitude, circle.Center.Longitude + degressLongitude));
        }

        private readonly double _radiusInNauticalMiles;

        public override double Area()
        {
            throw new NotImplementedException();
        }

        public override Point Centroid()
        {
            throw new NotImplementedException();
        }

        public override Geography Intersect(Geography geography)
        {
            throw new NotImplementedException();
        }

        public override Geography Union(Geography geography)
        {
            throw new NotImplementedException();
        }

        protected override bool PrecisionContains(Point point)
        {
            return ((Circle)Geography).Center.GeodesicDistance(point).ConvertTo(Metrics.UnitsOfMeasure.NauticalMile).Value <= _radiusInNauticalMiles;
        }
    }
}
