using System;

namespace Sumo.Geo.Metrics
{
    public partial class Distance
    {
        public Distance() { }

        public Distance(double value, UnitsOfLength units)
        {
            Value = value;
            Units = units;
        }

        public Distance(Distance distance) : this(distance.Value, distance.Units)
        {
        }

        public double Value { get; set; }
        public UnitsOfLength Units { get; set; }

        public override string ToString()
        {
            var units = String.Empty;
            switch (Units)
            {
                case UnitsOfLength.Foot:
                    units = "ft";
                    break;
                case UnitsOfLength.Yard:
                    units = "yd";
                    break;
                case UnitsOfLength.Mile:
                    units = "mi";
                    break;
                case UnitsOfLength.Meter:
                    units = "m";
                    break;
                case UnitsOfLength.Kilometer:
                    units = "km";
                    break;
                case UnitsOfLength.NauticalMile:
                    units = "nmi";
                    break;
                default:
                    throw new NotSupportedException();
            }
            return $"{Value} {units}";
        }

        public Distance ConvertTo(UnitsOfLength units)
        {
            if (Units == units)
            {
                return this;
            }

            switch (units)
            {
                case UnitsOfLength.Foot:
                    return new Distance(Value.ToFoot(Units), units);
                case UnitsOfLength.Yard:
                    return new Distance(Value.ToYard(Units), units);
                case UnitsOfLength.Mile:
                    return new Distance(Value.ToMile(Units), units);
                case UnitsOfLength.Meter:
                    return new Distance(Value.ToMeter(Units), units);
                case UnitsOfLength.Kilometer:
                    return new Distance(Value.ToKilometer(Units), units);
                case UnitsOfLength.NauticalMile:
                    return new Distance(Value.ToNauticalMile(Units), units);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
