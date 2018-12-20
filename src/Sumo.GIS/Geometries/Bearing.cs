using Sumo.GIS.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sumo.GIS.Geometries
{
    //todo: finish implementing bearing
    public class Bearing
    {
        public CardinalDirections BaseLine { get; }
        public Angle Heading { get; }
    }
}
