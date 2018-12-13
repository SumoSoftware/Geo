using Sumo.Geo.Metrics;

namespace Sumo.Geo.Primitives
{
    public enum GeoPositionPrecision
    {
        Low,
        High
    }

    public interface IRegion : IGeography
    {
        GeoPoint Centroid { get; }

        bool Contains(GeoPoint point, GeoPositionPrecision precision = GeoPositionPrecision.High);
        bool Contains(IRegion region, GeoPositionPrecision precision = GeoPositionPrecision.High);

        bool Intersects(IRegion region);

        Area GetArea();

        IRegion GetIntersection(IRegion region);
        IRegion GetUnion(IRegion region);

        /// <summary>
        /// northwest bounding point
        /// </summary>
        GeoPoint NorthWest { get; }

        /// <summary>
        /// southeast bounding point
        /// </summary>
        GeoPoint SouthEast { get; }
    }
}
