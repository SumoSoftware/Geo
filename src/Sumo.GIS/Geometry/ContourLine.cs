using Sumo.GIS.Metrics;
using System.Collections.Generic;

namespace Sumo.GIS.Geometry
{
    /// <summary>
    /// https://www.nrcs.usda.gov/Internet/FSE_DOCUMENTS/nrcs144p2_051844.pdf
    /// functional surface  A surface representation which stores a single z-value (as opposed to multiple z-values) for any given x,y location.  Functional surfaces are also referred to as 2.5-dimensional surfaces.  
    /// </summary>
    public class ContourLine : Polygon
    {
        public ContourLine() : base()
        {
            Elevation = new Distance(0.0, UnitsOfLength.Foot);
        }

        public ContourLine(IEnumerable<Point> points, Distance elevation) : base(points)
        {
            Elevation = new Distance(elevation);
        }

        public Distance Elevation { get; set; }
    }
}
