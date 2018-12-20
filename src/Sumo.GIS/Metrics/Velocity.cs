using System;

namespace Sumo.GIS.Metrics
{
    public partial class Velocity : Speed
    {
        public Velocity()
        {
        }

        public Velocity(Distance distance, UnitsOfTime units, Angle azimuth) : base(distance, units)
        {
            if (azimuth == null)
            {
                throw new ArgumentNullException(nameof(azimuth));
            }

            Azimuth = new Angle(azimuth);
        }

        public Velocity(Velocity velocity) : this(velocity.Distance, velocity.Units, velocity.Azimuth)
        {
        }

        public Angle Azimuth { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} to {Azimuth}";
        }
    }
}
