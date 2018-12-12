using System;

namespace Sumo.Geo.Primitives
{
    public class Rectangle
    {
        public Rectangle()
        {
            NorthWest = new Point();
            SouthEast = new Point();
        }

        public Rectangle(Point northWest, Point southEast)
        {
            NorthWest = northWest ?? throw new ArgumentNullException(nameof(northWest));
            SouthEast = southEast ?? throw new ArgumentNullException(nameof(southEast));
        }

        public Point NorthWest { get; }
        public Point SouthEast { get; }

        public bool Contains(Point point)
        {
            return
                point.Latitude <= NorthWest.Latitude &&
                point.Latitude >= SouthEast.Latitude &&
                point.Longitude >= NorthWest.Longitude &&
                point.Longitude <= SouthEast.Longitude;
        }

        public override string ToString()
        {
            return String.Format($"[{NorthWest}, {SouthEast}]");
        }
    }
}
