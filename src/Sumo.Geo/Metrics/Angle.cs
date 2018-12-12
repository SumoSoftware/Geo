using System;

namespace Sumo.Geo.Metrics
{
    public partial class Angle
    {
        public Angle() { }

        public Angle(double value, UnitsOfAngle units)
        {
            Value = value;
            Units = units;
        }

        public Angle(Angle angle) : this(angle.Value, angle.Units)
        {
        }

        public double Value { get; set; }
        public UnitsOfAngle Units { get; set; }

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
