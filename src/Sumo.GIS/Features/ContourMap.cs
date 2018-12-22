using Sumo.GIS.GeometricFigures;
using System.Collections.Generic;

namespace Sumo.GIS.Features
{
    public class ContourMap : IModel
    {
        public string Name { get; set; }
        public Dictionary<string, object> Properties { get; } = new Dictionary<string, object>();

        public List<ContourLine> Lines { get; } = new List<ContourLine>();
    }
}
