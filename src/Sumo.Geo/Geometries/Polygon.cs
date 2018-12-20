using System.Collections.Generic;

namespace Sumo.Geo.Geometries
{
    /// <summary>
    /// first and last point must be identical
    /// </summary>
    public class Polygon : Path
    {
        public Polygon() : base() { }

        public Polygon(IEnumerable<OrderedPoint> points) : base(points)
        {
            if (Coordinates[0] != Coordinates[Coordinates.Count - 1])
            {
                Coordinates.Add(new OrderedPoint(Coordinates[0], Coordinates.Count));
            }
        }
    }
}
