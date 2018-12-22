using Sumo.GIS.Metrics;
using System;
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

        public ContourLine(IEnumerable<Point> points) : base(points)
        {
            var i = -1;
            foreach (var point in points)
            {
                ++i;
                if (Elevation == null)
                {
                    Elevation = new Distance(point.Elevation);
                    continue;
                }
                if (point.Elevation != Elevation)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(points)} contains an invalid elevation at index {i}.");
                }
            }
        }

        public Distance Elevation { get; private set; }

        public new void Add(Point point)
        {
            if (Count == 0)
            {
                Elevation = new Distance(point.Elevation);
            }
            else if (point.Elevation != Elevation)
            {
                throw new ArgumentOutOfRangeException($"{nameof(point)}.Elevation doesn't match contour line elevation.");
            }

            base.Add(point);
        }
    }
}
