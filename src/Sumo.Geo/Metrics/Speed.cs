using System;

namespace Sumo.Geo.Metrics
{
    public partial class Speed
    {
        public Speed() { }

        public Speed(Distance distance, UnitsOfTime units)
        {
            Distance = distance ?? throw new ArgumentNullException(nameof(distance));
            Units = units;
        }

        public Distance Distance { get; set; }
        public UnitsOfTime Units { get; set; }

        public override string ToString()
        {
            var units = String.Empty;
            switch (Units)
            {
                case UnitsOfTime.Second:
                    units = "s";
                    break;
                case UnitsOfTime.Minute:
                    units = "min";
                    break;
                case UnitsOfTime.Hour:
                    units = "hr";
                    break;
                case UnitsOfTime.Milisecond:
                    units = "ms";
                    break;
                case UnitsOfTime.Day:
                    units = "day";
                    break;
                default:
                    throw new NotSupportedException();
            }
            return $"{Distance}/{units}";
        }
    }
}
