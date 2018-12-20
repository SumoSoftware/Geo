//using Sumo.GIS.Features;
//using Sumo.GIS.Geometries;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Sumo.GIS.Evaluators
//{
//    public class PolygonEvaluator : RegionEvaluator
//    {
//        internal sealed class PolygonOptimizedLineSegment : LineSegment
//        {
//            public PolygonOptimizedLineSegment(Point point1, Point point2) : base(point1, point2)
//            {
//                EastBoundingPoint = point1.Longitude > point2.Longitude ? point1 : point2;
//                NorthBoundingPoint = point1.Latitude > point2.Latitude ? point1 : point2;
//                SouthBoundingPoint = point1.Latitude <= point2.Latitude ? point1 : point2;

//                // indicates that the segment is useless for slope intercept checks
//                IsHorizontal = point1.Latitude == point2.Latitude;
//            }

//            public Point EastBoundingPoint { get; }
//            public Point NorthBoundingPoint { get; }
//            public Point SouthBoundingPoint { get; }

//            /// <summary>
//            /// indicates that the segment is useless for slope intercept checks
//            /// </summary>
//            public bool IsHorizontal { get; }

//            public override string ToString()
//            {
//                return String.Format("{0} H={1}", base.ToString(), IsHorizontal);
//            }
//        }

//        public PolygonEvaluator(Polygon polygon) : base(polygon)
//        {
//            if (polygon.Perimeter.Points.Count < 3)
//            {
//                throw new Exception("polygon definition must have at least 3 points");
//            }

//            var segments = new List<PolygonOptimizedLineSegment>(polygon.Perimeter.Points.Count);
//            var i = 0;
//            for (i = 0; i < polygon.Perimeter.Points.Count - 1; ++i)
//            {
//                if (polygon.Perimeter.Points[i].Latitude != polygon.Perimeter.Points[i + 1].Latitude) // don't add horizontal points
//                {
//                    segments.Add(new PolygonOptimizedLineSegment(polygon.Perimeter.Points[i], polygon.Perimeter.Points[i + 1]));
//                }
//            }

//            if (polygon.Perimeter.Points[i].Latitude != polygon.Perimeter.Points[0].Latitude) // don't add horizontal points
//            {
//                segments.Add(new PolygonOptimizedLineSegment(polygon.Perimeter.Points[i], polygon.Perimeter.Points[0]));
//            }

//            // order the segments by the west longitude because we compare slope intercept from west to east (left to right). 
//            // this lets us bypass all line segments that are horizontal (impossible to slope intercept test due to physics) 
//            // and segments that are west of the position (impossible to slope intercept because our vector points the opposite direction)
//            _segments = segments.OrderBy(ls => ls.EastBoundingPoint.Longitude).ToArray();
//        }

//        private PolygonOptimizedLineSegment[] _segments;

//        protected override bool PrecisionContains(Point point)
//        {
//            var intersections = 0;

//            // skip the line segments with no east portion of the position - they're useless 
//            // (binary search might be faster)
//            var indexStart = 0;
//            for (var i = 0; i < _segments.Length; ++i)
//            {
//                if (_segments[i].EastBoundingPoint.Longitude >= point.Longitude)
//                {
//                    indexStart = i;
//                    break;
//                }
//            }

//            for (var i = indexStart; i < _segments.Length; ++i)
//            {
//                var segment = _segments[i];

//                // if the position touches either of the endpoints of the segment then the point is contained
//                if (point.Equals(segment.SouthBoundingPoint) || point.Equals(segment.NorthBoundingPoint))
//                {
//                    return true;
//                }

//                // don't have to check for horizontal segments because they're already optimized out of the segment array during the constructor
//                // removed check for slope intercept because scanning the latitude is faster
//                if (point.Latitude <= segment.NorthBoundingPoint.Latitude && point.Latitude >= segment.SouthBoundingPoint.Latitude)
//                {
//                    intersections++;
//                }
//            }
//            return (intersections != 0) && (intersections % 2 != 0);
//        }
//    }
//}
