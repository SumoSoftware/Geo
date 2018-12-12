using System;
using System.Collections.Generic;

namespace Sumo.Geo.Metrics
{
    public enum UnitsOfTime
    {
        Second,
        Minute,
        Hour,
        Milisecond,
        Day
    }

    public class Speed : IEquatable<Speed>
    {
        public Speed() { }

        public Speed(Distance distance, UnitsOfTime units)
        {
            Distance = distance ?? throw new ArgumentNullException(nameof(distance));
            Units = units;
        }

        public Distance Distance { get; set; }
        public UnitsOfTime Units { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Speed);
        }

        public bool Equals(Speed other)
        {
            return other != null &&
                   EqualityComparer<Distance>.Default.Equals(Distance, other.Distance) &&
                   Units == other.Units;
        }

        public override int GetHashCode()
        {
            var hashCode = 1591325966;
            hashCode = hashCode * -1521134295 + EqualityComparer<Distance>.Default.GetHashCode(Distance);
            hashCode = hashCode * -1521134295 + Units.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Speed speed1, Speed speed2)
        {
            return EqualityComparer<Speed>.Default.Equals(speed1, speed2);
        }

        public static bool operator !=(Speed speed1, Speed speed2)
        {
            return !(speed1 == speed2);
        }

        public override string ToString()
        {
            var units = string.Empty;
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
                    break;
            }
            return $"{Distance}/{units}";
        }
    }
}
