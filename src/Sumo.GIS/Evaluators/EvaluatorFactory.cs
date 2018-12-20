//using Sumo.GIS.Features;
//using System;

//namespace Sumo.GIS.Evaluators
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
