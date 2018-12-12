using System;
using System.Collections.Generic;

namespace Sumo.Geo.Metrics
{
    public enum UnitsOfMeasure
    {
        Foot,
        Yard,
        Mile,
        Meter,
        Kilometer,
        NauticalMile
    }

    public class Distance : IEquatable<Distance>
    {
        public Distance() { }

        public Distance(double value, UnitsOfMeasure units)
        {
            Value = value;
            Units = units;
        }

        public double Value { get; set; }
        public UnitsOfMeasure Units { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Distance);
        }

        public bool Equals(Distance other)
        {
            return other != null &&
                   Value == other.Value &&
                   Units == other.Units;
        }

        public override int GetHashCode()
        {
            var hashCode = -77776330;
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            hashCode = hashCode * -1521134295 + Units.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Distance distance1, Distance distance2)
        {
            return EqualityComparer<Distance>.Default.Equals(distance1, distance2);
        }

        public static bool operator !=(Distance distance1, Distance distance2)
        {
            return !(distance1 == distance2);
        }

        public override string ToString()
        {
            var units = String.Empty;
            switch (Units)
            {
                case UnitsOfMeasure.Foot:
                    units = "ft";
                    break;
                case UnitsOfMeasure.Yard:
                    units = "yd";
                    break;
                case UnitsOfMeasure.Mile:
                    units = "mi";
                    break;
                case UnitsOfMeasure.Meter:
                    units = "m";
                    break;
                case UnitsOfMeasure.Kilometer:
                    units = "km";
                    break;
                case UnitsOfMeasure.NauticalMile:
                    units = "nmi";
                    break;
                default:
                    throw new NotSupportedException();
            }
            return $"{Value} {units}";
        }

        public Distance ConvertTo(UnitsOfMeasure units)
        {
            if (Units == units)
            {
                return this;
            }

            switch (units)
            {
                case UnitsOfMeasure.Foot:
                    return new Distance(Value.ToFoot(Units), units);
                case UnitsOfMeasure.Yard:
                    return new Distance(Value.ToYard(Units), units);
                case UnitsOfMeasure.Mile:
                    return new Distance(Value.ToMile(Units), units);
                case UnitsOfMeasure.Meter:
                    return new Distance(Value.ToMeter(Units), units);
                case UnitsOfMeasure.Kilometer:
                    return new Distance(Value.ToKilometer(Units), units);
                case UnitsOfMeasure.NauticalMile:
                    return new Distance(Value.ToNauticalMile(Units), units);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
