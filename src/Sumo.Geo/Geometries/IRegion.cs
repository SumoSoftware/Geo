using Sumo.Geo.Metrics;

namespace Sumo.Geo.Geometries
{
    public interface IRegion : IGeometry 
    {
        Area GetArea();
    }
}
