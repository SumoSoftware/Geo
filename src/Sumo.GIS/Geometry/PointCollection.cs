using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.GIS.Geometry
{
    public partial class PointCollection : FigureCollection<Point>, IFigure
    {
        public PointCollection()
        {
        }

        public PointCollection(IEnumerable<Point> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }

            AddRange(points);
        }

        public override Rectangle GetExtent()
        {
            var northWest = new Point(this.Max((p) => p.Latitude), this.Min((p)=> p.Longitude));
            var southEast = new Point(this.Min((p) => p.Latitude), this.Max((p) => p.Longitude));
            return new Rectangle(northWest, southEast);
        }

        public override string ToString()
        {
            return $"[{String.Join(",", this)}]";
        }
    }
}
