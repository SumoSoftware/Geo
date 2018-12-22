using Sumo.GIS.Metrics;

namespace Sumo.GIS.Geometry
{
    public interface IShape : IFigure 
    {
        Area GetArea(UnitsOfLength units);
        Distance GetPerimeter();
        Point GetCentroid();
    }
}
