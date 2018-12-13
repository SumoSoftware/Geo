using Sumo.Geo.Primitives;
using System;

namespace Sumo.Geo.Geographies
{
    public partial class Box : Region
    {
        public Box()
        {
            NorthWest = new GeoPoint();
            SouthEast = new GeoPoint();
        }

        public Box(GeoPoint northWest, GeoPoint southEast)
        {
            NorthWest = northWest ?? throw new ArgumentNullException(nameof(northWest));
            SouthEast = southEast ?? throw new ArgumentNullException(nameof(southEast));
        }

        public override string ToString()
        {
            return String.Format($"[{NorthWest}, {SouthEast}]");
        }
    }
}
