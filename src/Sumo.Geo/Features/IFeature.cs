using Sumo.Geo.Geometries;
using System.Collections.Generic;

namespace Sumo.Geo.Features
{
    public interface IFeature
    {
        GeometryCollection Geometries { get; }
        Dictionary<string, object> Properties { get; }
    }
}
