namespace Sumo.Geo.Metrics
{
    public partial class Velocity : Speed
    {
        public Velocity()
        {
        }

        public Velocity(Distance distance, UnitsOfTime units, Angle heading) : base(distance, units)
        {
            Heading = heading;
        }

        public Angle Heading { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} to {Heading}";
        }
    }
}
