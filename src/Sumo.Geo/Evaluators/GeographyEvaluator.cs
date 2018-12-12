using Sumo.Geo.Geographies;
using Sumo.Geo.Primitives;
using System;

namespace Sumo.Geo.Evaluators
{
    public abstract class GeographyEvaluator
    {
        public GeographyEvaluator(Geography geography)
        {
            Geography = geography ?? throw new ArgumentNullException(nameof(geography));
        }

        public Geography Geography { get; }
        public Rectangle Bounds { get; protected set; }

        public bool Contains(Point point)
        {
            if (Bounds.Contains(point))
            {
                return PrecisionContains(point);
            }
            return false;
        }

        protected abstract bool PrecisionContains(Point point);

        public abstract Geography Union(Geography geography);

        public abstract Geography Intersect(Geography geography);

        //todo: create area type in metrics
        public abstract double Area();

        public abstract Point Centroid();

    }
}
