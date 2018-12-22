using Sumo.GIS.Metrics;

namespace Sumo.GIS.GeometricFigures
{
    public interface IShape : IFigure 
    {
        Area GetArea();
        Distance GetPerimeter();
        Point GetCentroid();
    }
}
