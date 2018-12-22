﻿using Sumo.GIS.Metrics;
using System.Collections.Generic;

namespace Sumo.GIS.Geometry
{
    /// <summary>
    /// linear feature  A geographic feature that can be represented by a line or set of lines.  For example, rivers, roads, and electric and telecommunication networks are all linear features.  
    /// </summary>
    public class Path : PointCollection, IFigure
    {
        public Path()
        {
        }

        public Path(IEnumerable<Point> points) : base(points)
        {
        }

        public Distance GetDistance()
        {
            var value = 0.0;
            for (var i = 0; i < Count - 2; ++i)
            {
                value += this[i].GetDistance(this[i + 1], UnitsOfLength.NauticalMile).Value;
            }
            return new Distance(value, UnitsOfLength.NauticalMile);
        }
    }
}
