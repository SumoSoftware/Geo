using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;
using System;
using System.Linq;

namespace Sumo.Geo.Geographies
{
    public class Trail : Region
    {
        public Trail() { }

        public Trail(GeoPath path, Distance stroke)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            Stroke = stroke ?? throw new ArgumentNullException(nameof(stroke));
        }

        private double _widthInNauticalMiles;

        public GeoPath Path { get; set; }

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

        protected override GeoBox GetBounds()
        {
            return new GeoBox(
                new GeoPoint(Path.Points.Max(p => p.Latitude), Path.Points.Min(p => p.Longitude)),
                new GeoPoint(Path.Points.Min(p => p.Latitude), Path.Points.Max(p => p.Longitude)));
        }

        protected override bool PrecisionContains(GeoPoint point)
        {
            throw new NotImplementedException();
        }
    }
}
