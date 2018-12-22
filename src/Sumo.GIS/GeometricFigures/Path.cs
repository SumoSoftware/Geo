using System.Collections.Generic;

namespace Sumo.GIS.GeometricFigures
{
    public class Path : PointCollection, IFigure
    {
        public Path()
        {
        }

        public Path(IEnumerable<Point> points) : base(points)
        {
        }
    }
}
