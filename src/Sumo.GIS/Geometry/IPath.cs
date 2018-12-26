using Sumo.GIS.Metrics;
using System.Collections.Generic;

namespace Sumo.GIS.Geometry
{
    public interface IPath : IEnumerable<Point>
    {
        Point Origin { get; }
        Point Terminus { get; }
        Distance GetDistance(UnitsOfLength units);
    }
}
