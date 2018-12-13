using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;
using System;
using System.Collections.Generic;

namespace Sumo.Geo.Geographies
{
    public partial class Corridor : GeoPointCollection, IEquatable<Corridor>
    {
        public Corridor() { }

        public Corridor(IEnumerable<GeoPoint> points, Distance stroke) : base(points)
        {
            Stroke = stroke ?? throw new ArgumentNullException(nameof(stroke));
        }

        private double _widthInNauticalMiles;

        private Distance _stroke;
        public Distance Stroke
        {
            get => _stroke;
            set
            {
                _stroke = value;
                _widthInNauticalMiles = Stroke.ConvertTo(UnitsOfLength.NauticalMile).Value;
            }
        }

        protected override bool PrecisionContains(GeoPoint point)
        {
            throw new NotImplementedException();
        }
    }
}
