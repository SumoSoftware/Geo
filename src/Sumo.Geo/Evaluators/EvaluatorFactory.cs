//using Sumo.Geo.Geographies;
//using System;

//namespace Sumo.Geo.Evaluators
//{
//    public class EvaluatorFactory : IEvaluatorFactory
//    {
//        public IRegionEvaluator Create(Region region)
//        {
//            if (region is Circle)
//            {
//                return new CircleEvaluator(region as Circle);
//            }
//            else if (region is Polygon)
//            {
//                return new PolygonEvaluator(region as Polygon);
//            }
//            else if (region is Corridor)
//            {
//                return new CorridorEvaluator(region as Corridor);
//            }
//            else
//            {
//                throw new NotSupportedException();
//            }
//        }
//    }
//}
