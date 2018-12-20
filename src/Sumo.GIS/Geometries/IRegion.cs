using Sumo.GIS.Metrics;

namespace Sumo.GIS.Geometries
{
    public interface IRegion : IGeometry 
    {
        Area GetArea();
    }
}
