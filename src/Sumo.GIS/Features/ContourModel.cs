using Sumo.GIS.Geometry;
using System.Collections.Generic;

namespace Sumo.GIS.Features
{
    public class ContourModel : FigureCollection<ContourLine>, IFeature, IModel<ContourLine>
    {
        public string Name { get; set; }
        public Dictionary<string, object> Properties { get; } = new Dictionary<string, object>();

        public FigureCollection<ContourLine> Figures => this;

        //todo: implement GetExtent
        public override Rectangle GetExtent()
        {
            throw new System.NotImplementedException();
        }
    }
}
