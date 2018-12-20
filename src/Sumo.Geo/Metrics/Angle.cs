using System;

namespace Sumo.Geo.Metrics
{
    public partial class Angle : IMetric
    {
        public Angle() { }

        public Angle(double value, UnitsOfAngle units)
        {
            Value = value;
            Units = units;
        }

        public Angle(double value) : this(value, UnitsOfAngle.Degree)
        {
        }

        public Angle(Angle angle) : this(angle.Value, angle.Units)
        {
        }

        public double Value { get; }
        public UnitsOfAngle Units { get; }

        public Angle ConvertTo(UnitsOfAngle units)
        {
            if (Units == units)
                return this;

            switch (Units)
            {
                case UnitsOfAngle.Degree:
                    switch (units)
                    {
                        case UnitsOfAngle.Radian:
                            return new Angle(Value.ToRadians(), units);
                        case UnitsOfAngle.BinaryDegree:
                        case UnitsOfAngle.ClockPosition:
                        case UnitsOfAngle.CompassPoint:
                        case UnitsOfAngle.Degree:
                        case UnitsOfAngle.Gradian:
                        case UnitsOfAngle.Milliradian:
                        case UnitsOfAngle.MinuteOfArc:
                        case UnitsOfAngle.Quadrant:
                        case UnitsOfAngle.SecondOfArc:
                        case UnitsOfAngle.Sextant:
                        case UnitsOfAngle.Turn:
                        default:
                            throw new NotSupportedException($"{nameof(units)}: {units}");
                    }
                case UnitsOfAngle.Radian:
                    switch (units)
                    {
                        case UnitsOfAngle.Degree:
                            return new Angle(Value.ToDegrees(), units);
                        case UnitsOfAngle.Radian:
                        case UnitsOfAngle.BinaryDegree:
                        case UnitsOfAngle.ClockPosition:
                        case UnitsOfAngle.CompassPoint:
                        case UnitsOfAngle.Gradian:
                        case UnitsOfAngle.Milliradian:
                        case UnitsOfAngle.MinuteOfArc:
                        case UnitsOfAngle.Quadrant:
                        case UnitsOfAngle.SecondOfArc:
                        case UnitsOfAngle.Sextant:
                        case UnitsOfAngle.Turn:
                        default:
                            throw new NotSupportedException($"{nameof(units)}: {units}");
                    }
                case UnitsOfAngle.BinaryDegree:
                case UnitsOfAngle.ClockPosition:
                case UnitsOfAngle.CompassPoint:
                case UnitsOfAngle.Gradian:
                case UnitsOfAngle.Milliradian:
                case UnitsOfAngle.MinuteOfArc:
                case UnitsOfAngle.Quadrant:
                case UnitsOfAngle.SecondOfArc:
                case UnitsOfAngle.Sextant:
                case UnitsOfAngle.Turn:
                default:
                    throw new NotSupportedException($"{nameof(units)}: {units}");
            }
        }

        public override string ToString()
        {
            var units = Units.ToString();
            switch (Units)
            {
                case UnitsOfAngle.BinaryDegree:
                    break;
                case UnitsOfAngle.ClockPosition:
                    break;
                case UnitsOfAngle.CompassPoint:
                    break;
                case UnitsOfAngle.Degree:
                    break;
                case UnitsOfAngle.Gradian:
                    break;
                case UnitsOfAngle.Milliradian:
                    break;
                case UnitsOfAngle.MinuteOfArc:
                    break;
                case UnitsOfAngle.Quadrant:
                    break;
                case UnitsOfAngle.Radian:
                    break;
                case UnitsOfAngle.SecondOfArc:
                    break;
                case UnitsOfAngle.Sextant:
                    break;
                case UnitsOfAngle.Turn:
                    break;
                default:
                    throw new NotSupportedException();

            }
            return $"{Value} {units}";
        }
    }
}
