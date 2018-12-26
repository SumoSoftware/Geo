using Sumo.GIS.Metrics;

namespace Sumo.GIS.Geometry
{
    public interface IPath
    {
        Point Origin { get; }
        Point Terminus { get; }
        Distance GetDistance(UnitsOfLength units);
    }
}
