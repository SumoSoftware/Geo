using Sumo.GIS.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sumo.GIS.GeometricFigures
{
    /// <summary>
    /// first and last point must be identical so if they aren't we add a point to close the polygon
    /// </summary>
    public class Polygon : Path, IShape
    {
        public Polygon() : base() { }

        public Polygon(IEnumerable<Point> points) : base(points)
        {
            if (points.Count() < 3)
            {
                throw new ArgumentOutOfRangeException(nameof(points));
            }

            if (this[0] != this[Count - 1])
            {
                Add(new Point(this[0]));
            }
        }

        public virtual Area GetArea(UnitsOfLength units)
        {
            //https://planetcalc.com/1466/
            //https://www.mathsisfun.com/geometry/herons-formula.html

            double area = 0.0;
            for (var i = 1; i < Count - 2; ++i)
            {
                var a = this[0].GetDistance(this[i], units);
                var b = this[i].GetDistance(this[i + 1], units);
                var c = this[0].GetDistance(this[i + 1], units);
                var s = (a + b + c) / 2.0;
                var x = s.Value * (s - a).Value * (s - b).Value * (s - c).Value;
                area += Math.Sqrt(x);
            }
            return new Area(area, units);
        }

        public Point GetCentroid()
        {
            var avgLatitude = this.Sum((p) => p.Latitude) / Count;
            var avgLongitude = this.Sum((p) => p.Longitude) / Count;
            var avgElevation = new Distance(this.Sum((p) => p.Elevation.ConvertTo(UnitsOfLength.Meter).Value) / Count, UnitsOfLength.Meter);
            return new Point(avgLatitude, avgLongitude, avgElevation);
        }

        public Distance GetPerimeter()
        {
            return GetDistance();
        }
    }
}
