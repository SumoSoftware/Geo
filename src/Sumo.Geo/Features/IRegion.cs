//using Sumo.Geo.Metrics;

//namespace Sumo.Geo.Geometries
//{
//    public enum GeoPositionPrecision
//    {
//        Low,
//        High
//    }

//    public interface IRegion : IGeography
//    {
//        Point Centroid { get; }

//        bool Contains(Point point, GeoPositionPrecision precision = GeoPositionPrecision.High);
//        bool Contains(IRegion region, GeoPositionPrecision precision = GeoPositionPrecision.High);

//        bool Intersects(IRegion region);

//        Area GetArea();

//        IRegion GetIntersection(IRegion region);
//        IRegion GetUnion(IRegion region);

//        /// <summary>
//        /// northwest bounding point
//        /// </summary>
//        Point NorthWest { get; }

//        /// <summary>
//        /// southeast bounding point
//        /// </summary>
//        Point SouthEast { get; }
//    }
//}
