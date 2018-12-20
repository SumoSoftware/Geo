using System;

namespace Sumo.GIS.Metrics
{
    public partial class Area : IMetric
    {
        public Area() { }

        public Area(double value, UnitsOfLength units)
        {
            Value = value;
            Units = units;
        }

        public Area(Area area) : this(area.Value, area.Units)
        {
        }

        public double Value { get; }
        public UnitsOfLength Units { get; }

        public override string ToString()
        {
            var units = String.Empty;
            switch (Units)
            {
                case UnitsOfLength.Foot:
                    units = "ft2";
                    break;
                case UnitsOfLength.Yard:
                    units = "yd2";
                    break;
                case UnitsOfLength.Mile:
                    units = "mi2";
                    break;
                case UnitsOfLength.Meter:
                    units = "m2";
                    break;
                case UnitsOfLength.Kilometer:
                    units = "km2";
                    break;
                case UnitsOfLength.NauticalMile:
                    units = "nmi2";
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
