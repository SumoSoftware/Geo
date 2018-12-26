using System;
using System.Collections.Generic;

namespace Sumo.GIS.Features
{
    public class Annotation : IFeature
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Dictionary<string, object> Properties => throw new NotImplementedException();
    }
}
