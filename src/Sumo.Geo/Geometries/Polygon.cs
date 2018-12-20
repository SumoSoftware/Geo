using Sumo.Geo.Metrics;
using System;
using System.Collections.Generic;

namespace Sumo.Geo.Geometries
{
    /// <summary>
    /// first and last point must be identical so if they aren't we add a point to close the polygon
    /// </summary>
    public class Polygon : Path, IRegion
    {
        public Polygon() : base() { }

        public Polygon(IEnumerable<Point> points) : base(points)
        {
            if (Coordinates[0] != Coordinates[Coordinates.Count - 1])
            {
                Coordinates.Add(new Point(Coordinates[0]));
            }
        }

        public virtual Area GetArea()
        {
            throw new NotImplementedException();
        }
    }
}
