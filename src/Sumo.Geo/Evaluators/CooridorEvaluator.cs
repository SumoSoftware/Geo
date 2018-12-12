using Sumo.Geo.Geographies;
using Sumo.Geo.Primitives;
using System;
using System.Linq;

namespace Sumo.Geo.Evaluators
{
    public class CooridorEvaluator : RegionEvaluator
    {
        internal sealed class OptimizedCorridorLineSegment : LineSegment
        {
            public OptimizedCorridorLineSegment(GeoPoint point1, GeoPoint point2, double widthInNauticalMiles) :
                base(point1, point2)
            {
                // when == it's a horizontal line. is that a problem?
                _halfWidthInNauticalMiles = widthInNauticalMiles / 2.0;

                var northWest = new GeoPoint(
                    (point1.Latitude >= point2.Latitude ? point1.Latitude : point2.Latitude) + Geography.DegreesLatitudePerNauticalMile * _halfWidthInNauticalMiles,
                    point1.Longitude <= point2.Longitude ? point1.Longitude : point2.Longitude);
                northWest.Longitude -= Geography.GetDegreesLongitudePerNauticalMile(northWest.Longitude) * _halfWidthInNauticalMiles;

                var southEast = new GeoPoint(
                    (point1.Latitude <= point2.Latitude ? point1.Latitude : point2.Latitude) - Geography.DegreesLatitudePerNauticalMile * _halfWidthInNauticalMiles,
                    point1.Longitude >= point2.Longitude ? point1.Longitude : point2.Longitude);
                southEast.Longitude += Geography.GetDegreesLongitudePerNauticalMile(southEast.Longitude) * _halfWidthInNauticalMiles;

                _bounds = new GeoBox(northWest, southEast);

                // putting boxes around the end caps
                _point1Box = new GeoBox(
                    new GeoPoint(point1.Latitude + Geography.DegreesLatitudePerNauticalMile * _halfWidthInNauticalMiles, point1.Longitude - Geography.GetDegreesLongitudePerNauticalMile(point1.Longitude) * _halfWidthInNauticalMiles),
                    new GeoPoint(point1.Latitude - Geography.DegreesLatitudePerNauticalMile * _halfWidthInNauticalMiles, point1.Longitude + Geography.GetDegreesLongitudePerNauticalMile(point1.Longitude) * _halfWidthInNauticalMiles));

                _point1Box = new GeoBox(
                    new GeoPoint(point2.Latitude + Geography.DegreesLatitudePerNauticalMile * _halfWidthInNauticalMiles, point2.Longitude - Geography.GetDegreesLongitudePerNauticalMile(point2.Longitude) * _halfWidthInNauticalMiles),
                    new GeoPoint(point2.Latitude - Geography.DegreesLatitudePerNauticalMile * _halfWidthInNauticalMiles, point2.Longitude + Geography.GetDegreesLongitudePerNauticalMile(point2.Longitude) * _halfWidthInNauticalMiles));
            }

            private readonly double _halfWidthInNauticalMiles;
            private readonly GeoBox _point1Box;
            private readonly GeoBox _point2Box;
            private readonly GeoBox _bounds;

            public bool Contains(GeoPoint point)
            {
                if (_bounds.Contains(point))
                {
                    return PrecisionContains(point);
                }
                return false;
            }

            public bool PrecisionContains(GeoPoint point)
            {
                // check the end cap boxes around the starting and ending points first
                var result = _point1Box.Contains(point);
                if (!result)
                {
                    result = _point2Box.Contains(point);
                }

                if (result)
                {
                    return result;
                }

                //http://stackoverflow.com/questions/465942/which-algorithm-can-efficiently-find-a-set-of-points-within-a-certain-distance-o
                // this method uses flat 2D distance and will not work great in extreme northern or southern latitudes
                //https://en.wikipedia.org/wiki/Distance_from_a_point_to_a_line
                var startingPoint = Points[0];
                var endingPoint = Points[1];

                var a = point.Longitude - startingPoint.Longitude;
                var b = point.Latitude - startingPoint.Latitude;
                var c = endingPoint.Longitude - startingPoint.Longitude;
                var d = endingPoint.Latitude - startingPoint.Latitude;

                var dot = a * c + b * d;
                var len_sq = c * c + d * d;

                var distance = 0.0;
                if (len_sq == 0)
                {
                    distance = Math.Sqrt(
                        (startingPoint.Longitude - point.Longitude) * (startingPoint.Longitude - point.Longitude) +
                        (startingPoint.Latitude - point.Latitude) * (startingPoint.Latitude - point.Latitude));
                }
                else
                {
                    var param = dot / len_sq;
                    double xx, yy;

                    if (param < 0)
                    {
                        xx = startingPoint.Longitude;
                        yy = startingPoint.Latitude;
                    }
                    else if (param > 1)
                    {
                        xx = endingPoint.Longitude;
                        yy = endingPoint.Latitude;
                    }
                    else
                    {
                        xx = startingPoint.Longitude + param * c;
                        yy = startingPoint.Latitude + param * d;
                    }

                    distance = Math.Sqrt((point.Longitude - xx) * (point.Longitude - xx) + (point.Latitude - yy) * (point.Latitude - yy));
                }
                result = distance <= _halfWidthInNauticalMiles;

                return result;
            }
        }

        public CooridorEvaluator(Cooridor cooridor) : base(cooridor)
        {
            _widthInNauticalMiles = cooridor.Stroke.ConvertTo(Metrics.UnitsOfLength.NauticalMile).Value;

            Bounds = new GeoBox(
                new GeoPoint(cooridor.Path.Points.Max(p => p.Latitude), cooridor.Path.Points.Min(p => p.Longitude)),
                new GeoPoint(cooridor.Path.Points.Min(p => p.Latitude), cooridor.Path.Points.Max(p => p.Longitude)));

            _segments = new OptimizedCorridorLineSegment[cooridor.Path.Points.Count - 1];
            var j = 0;
            for (var i = 0; i < cooridor.Path.Points.Count - 2; ++i)
            {
                _segments[++j] = new OptimizedCorridorLineSegment(cooridor.Path.Points[i], cooridor.Path.Points[i + 1], _widthInNauticalMiles);
            }
        }

        private readonly OptimizedCorridorLineSegment[] _segments;
        private readonly double _widthInNauticalMiles;

        protected override bool PrecisionContains(GeoPoint point)
        {
            // todo: the next posible optimization would be to sort the segements 
            // in a way to allow a binary search for the nearest
            for (var i = 0; i < _segments.Length; ++i)
            {
                var segment = _segments[i];
                if( segment.Contains(point))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
