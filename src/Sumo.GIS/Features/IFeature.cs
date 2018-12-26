using System.Collections.Generic;

namespace Sumo.GIS.Features
{
    public interface IFeature
    {
        string Name { get; set; }

        Dictionary<string, object> Properties { get; }
    }
}
