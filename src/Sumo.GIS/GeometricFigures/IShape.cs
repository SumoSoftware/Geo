using Sumo.GIS.Metrics;

namespace Sumo.GIS.GeometricFigures
{
    public interface IShape : IFigure 
    {
        Area GetArea(UnitsOfLength units);
        Distance GetPerimeter();
        Point GetCentroid();
    }
}
