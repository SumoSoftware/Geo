using System;

namespace Sumo.Geo.Metrics
{
    public partial class Area
    {
        public Area() { }

        public Area(double value, UnitsOfLength units)
        {
            Value = value;
            Units = units;
        }

        public double Value { get; set; }
        public UnitsOfLength Units { get; set; }

        public override string ToString()
        {
            var units = String.Empty;
            switch (Units)
            {
                case UnitsOfLength.Foot:
                    units = "sq ft";
                    break;
                case UnitsOfLength.Yard:
                    units = "sq yd";
                    break;
                case UnitsOfLength.Mile:
                    units = "sq mi";
                    break;
                case UnitsOfLength.Meter:
                    units = "sq m";
                    break;
                case UnitsOfLength.Kilometer:
                    units = "sq km";
                    break;
                case UnitsOfLength.NauticalMile:
                    units = "sq nmi";
                    break;
                default:
                    throw new NotSupportedException();
            }
            return $"{Value} {units}";
        }

        public Area ConvertTo(UnitsOfLength units)
        {
            if (Units == units)
            {
                return this;
            }

            switch (units)
            {
                case UnitsOfLength.Foot:
                    return new Area(Value.ToFoot(Units), units);
                case UnitsOfLength.Yard:
                    return new Area(Value.ToYard(Units), units);
                case UnitsOfLength.Mile:
                    return new Area(Value.ToMile(Units), units);
                case UnitsOfLength.Meter:
                    return new Area(Value.ToMeter(Units), units);
                case UnitsOfLength.Kilometer:
                    return new Area(Value.ToKilometer(Units), units);
                case UnitsOfLength.NauticalMile:
                    return new Area(Value.ToNauticalMile(Units), units);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
