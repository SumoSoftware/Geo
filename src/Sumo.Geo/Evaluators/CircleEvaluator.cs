using Sumo.Geo.Geographies;
using Sumo.Geo.Primitives;
using System;

namespace Sumo.Geo.Evaluators
{
    public class CircleEvaluator : RegionEvaluator
    {
        public CircleEvaluator(Circle circle) : base(circle)
        {
            _radiusInNauticalMiles = circle.Radius.ConvertTo(Metrics.UnitsOfLength.NauticalMile).Value;

            var degreesLatitude = Geography.DegreesLatitudePerNauticalMile * _radiusInNauticalMiles;
            var degressLongitude = Geography.GetDegreesLongitudePerNauticalMile(circle.Center.Latitude) * _radiusInNauticalMiles;
        }

        private readonly double _radiusInNauticalMiles;

        protected override bool PrecisionContains(GeoPoint point)
        {
            return ((Circle)Region).Center.GetDistance(point, Metrics.UnitsOfLength.NauticalMile).Value <= _radiusInNauticalMiles;
        }
    }
}
