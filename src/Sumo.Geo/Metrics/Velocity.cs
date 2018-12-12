using System;

namespace Sumo.Geo.Metrics
{
    public partial class Velocity : Speed
    {
        public Velocity()
        {
        }

        public Velocity(Distance distance, UnitsOfTime units, Angle heading) : base(distance, units)
        {
            if (heading == null)
            {
                throw new ArgumentNullException(nameof(heading));
            }

            Heading = new Angle(heading);
        }

        public Velocity(Velocity velocity) : this(velocity.Distance, velocity.Units, velocity.Heading)
        {
        }

        public Angle Heading { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} to {Heading}";
        }
    }
}
