using System.Collections.Generic;

namespace Sumo.GIS.Features
{
    public interface IModel
    {
        string Name { get; set; }
        Dictionary<string, object> Properties { get; }
    }
}
