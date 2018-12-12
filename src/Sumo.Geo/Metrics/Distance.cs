using System;

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

    public partial class Distance
    {
        public Distance() { }

        public Distance(double value, UnitsOfMeasure units)
        {
            Value = value;
            Units = units;
        }

        public double Value { get; set; }
        public UnitsOfMeasure Units { get; set; }

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
