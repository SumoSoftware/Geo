using Sumo.Geo.Metrics;

namespace Sumo.Geo.Primitives
{
    public enum GeoPositionPrecision
    {
        Low,
        High
    }

    public interface IGeoRegion : IGeography
    {
        GeoPoint Centroid { get; }

        bool Contains(GeoPoint point, GeoPositionPrecision precision = GeoPositionPrecision.High);
        bool Contains(IGeoRegion region, GeoPositionPrecision precision = GeoPositionPrecision.High);

        bool Intersects(IGeoRegion region);

        Area GetArea();

        IGeoRegion GetIntersection(IGeoRegion region);
        IGeoRegion GetUnion(IGeoRegion region);

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
