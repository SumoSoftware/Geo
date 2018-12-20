using System.Collections.Generic;

namespace Sumo.Geo.Geometries
{
    public class Path : PointCollection, IGeometry
    {
        public Path()
        {
        }

        public Path(IEnumerable<Point> points) : base(points)
        {
        }
    }
}
