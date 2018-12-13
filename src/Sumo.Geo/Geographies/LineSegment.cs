using Sumo.Geo.Metrics;
using Sumo.Geo.Primitives;
using System;
using System.Linq;

namespace Sumo.Geo.Geographies
{
    public partial class LineSegment : Region
    {
        public LineSegment()
        {
            Points = new GeoPoint[2];
        }

        public LineSegment(GeoPoint point1, GeoPoint point2)
        {
            if (point1 == null)
            {
                throw new ArgumentNullException(nameof(point1));
            }

            if (point2 == null)
            {
                throw new ArgumentNullException(nameof(point2));
            }

            Points = new GeoPoint[] { point1, point2 };
        }

        public LineSegment(double lat1, double lon1, double lat2, double lon2) : this(new GeoPoint(lat1, lon1), new GeoPoint(lat2, lon2))
        {
        }

        public LineSegment(LineSegment lineSegment) : this(lineSegment?.Points[0], lineSegment?.Points[1])
        {
        }

        public GeoPoint[] Points { get; }

        /// <summary>
        /// returns geodesic distance (great arc)
        /// </summary>
        /// <returns></returns>
        public Distance GetLength(UnitsOfLength units = UnitsOfLength.NauticalMile)
        {
            return Points[0].GetDistance(Points[1], units);
        }

        public Angle GetHeading()
        {
            return Points[0].GetHeading(Points[1]);
        }

        public override string ToString()
        {
            return String.Format($"[{Points[0]}, {Points[1]}]");
        }

        protected override void SetBounds()
        {
            NorthWest = new GeoPoint(Points.Max(p => p.Latitude), Points.Min(p => p.Longitude));
            SouthEast = new GeoPoint(Points.Min(p => p.Latitude), Points.Max(p => p.Longitude));
        }
    }
}
