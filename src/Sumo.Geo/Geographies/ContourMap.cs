using System.Collections.Generic;
using Sumo.Geo.Primitives;

namespace Sumo.Geo.Geographies
{
    public class ContourMap : Geography
    {
        public List<Polygon> ContourLines { get; set; }

        protected override Box GetBounds()
        {
            throw new System.NotImplementedException();
        }
    }
}
