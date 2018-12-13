using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;
using System;
using System.Linq;

namespace Sumo.Geo.Geographies
{
    /// <summary>
    /// polygon is a closed path
    /// </summary>
    public partial class Polygon : Path, IEquatable<Polygon>
    {
        protected override bool PrecisionContains(GeoPoint point)
        {
            throw new NotImplementedException();
        }

        public override Area GetArea()
        {
            //todo: https://m.wikihow.com/Calculate-the-Area-of-a-Polygon
            throw new NotImplementedException();
        }
    }
}
