using System;

namespace Sumo.GIS.Metrics
{
    public partial class Speed : IMetric
    {
        public Speed() { }

        public Speed(Distance distance, UnitsOfTime units)
        {
            if (distance == null)
            {
                throw new ArgumentNullException(nameof(distance));
            }

            Distance = new Distance(distance);
            Units = units;
        }

        public Speed(Speed speed) : this(speed.Distance, speed.Units)
        {
        }

        public Distance Distance { get; }
        public UnitsOfTime Units { get; }

        public Speed ConvertTo(UnitsOfTime units)
        {
            if (Units == units)
            {
                return this;
            }

            // 1. convert current time unit to seconds
            var seconds = 1.0;
            switch (Units)
            {
                case UnitsOfTime.Minute:
                    seconds = 60;
                    break;
                case UnitsOfTime.Hour:
                    seconds = 3600;
                    break;
                case UnitsOfTime.Milisecond:
                    seconds = 0.001;
                    break;
                case UnitsOfTime.Day:
                    seconds = 86400;
                    break;
            }

            // 2. convert distance/time to distance over seconds
            var rate = Distance.Value / seconds;

            // 3. convert rate to new value
            switch (units)
            {
                case UnitsOfTime.Minute:
                    rate = rate * 60;
                    break;
                case UnitsOfTime.Hour:
                    rate = rate * 3600;
                    break;
                case UnitsOfTime.Milisecond:
                    rate = rate * 0.001;
                    break;
                case UnitsOfTime.Day:
                    rate = rate * 86400;
                    break;
            }

            return new Speed(new Distance(rate, Distance.Units), units);
        }

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
