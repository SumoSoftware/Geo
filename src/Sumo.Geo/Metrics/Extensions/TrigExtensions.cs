using System;

namespace Sumo.Geo.Metrics
{
    public static class TrigExtensions
    {
        public static double ToRadians(this double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }

        public static double ToDegrees(this double radians)
        {
            return (180.0 / Math.PI) * radians;
        }
    }
}
