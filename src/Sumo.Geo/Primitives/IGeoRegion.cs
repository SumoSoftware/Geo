using Sumo.Geo.Metrics;

namespace Sumo.Geo.Primitives
{
    public interface IGeoRegion : IGeoEntity
    {
        GeoPoint Centroid { get; }

        bool Contains(GeoPoint point);
        bool Contains(IGeoRegion region);
        bool Intersects(IGeoRegion region);

        Area GetArea();

        IGeoRegion GetIntersection(IGeoRegion region);
        IGeoRegion GetUnion(IGeoRegion region);
    }
}
