using Sumo.Geo.Metrics;
using System;

namespace Sumo.Geo.Primitives
{
    public interface IGeoEntity 
    {
        /// <summary>
        /// returns geodesic distance (great arc) between the entity and the provided GeoPoint
        /// </summary>
        /// <param name="geoEntity"></param>
        /// <returns></returns>
        Distance GetDistance(GeoPoint point, UnitsOfLength units = UnitsOfLength.NauticalMile);

        /// <summary>
        /// returns true if the entities is within the provided range provided of the provided GeoPoint
        /// </summary>
        /// <param name="geoEntity"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        bool IsWithinRange(GeoPoint point, Distance range);

        /// <summary>
        /// returns the geo displacement to the provided entity
        /// geo displacement is the direction and distance from a source entity to a destination - basically a vector
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Displacement GetDisplacement(GeoPoint point, UnitsOfLength units = UnitsOfLength.NauticalMile);

        GeoBox Bounds { get; set; }
    }
}
