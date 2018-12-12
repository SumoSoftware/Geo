using Sumo.Geo.Geographies;
using Sumo.Geo.Primitives;

namespace Sumo.Geo.Evaluators
{
    public interface IRegionEvaluator
    {
        bool Contains(Point point);

        //Geography Union(Geography geography);
        //Geography Intersect(Geography geography);
        ////todo: create area type in metrics
        //double Area();
        //Point Centroid();
    }
}
