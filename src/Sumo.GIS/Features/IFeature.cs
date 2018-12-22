using Sumo.GIS.GeometricFigures;
using System.Collections.Generic;

namespace Sumo.GIS.Features
{
    public interface IFeature
    {
        GeometryCollection Geometries { get; }
        Dictionary<string, object> Properties { get; }

        //Box Bounds { get; }
    }
}
