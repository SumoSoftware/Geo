namespace Sumo.Geo.Metrics
{
    public static class ConversionExtensions
    {
        public static double ToNauticalMile(this double value, UnitsOfMeasure unit)
        {
            var result = 0.0;
            switch (unit)
            {
                case UnitsOfMeasure.Foot:
                    result = value * 0.00016458;
                    break;
                case UnitsOfMeasure.Kilometer:
                    result = value * 0.5399568;
                    break;
                case UnitsOfMeasure.Meter:
                    result = value * 0.00053996;
                    break;
                case UnitsOfMeasure.Mile:
                    result = value * 0.86897624;
                    break;
                case UnitsOfMeasure.Yard:
                    result = value * 0.00049374;
                    break;
                case UnitsOfMeasure.NauticalMile:
                    result = value;
                    break;
            }
            return result;
        }

        public static double ToMile(this double value, UnitsOfMeasure unit)
        {
            var result = 0.0;
            switch (unit)
            {
                case UnitsOfMeasure.Foot:
                    result = value * 0.00018939;
                    break;
                case UnitsOfMeasure.Kilometer:
                    result = value * 0.62137119;
                    break;
                case UnitsOfMeasure.Meter:
                    result = value * 0.00062137;
                    break;
                case UnitsOfMeasure.Mile:
                    result = value;
                    break;
                case UnitsOfMeasure.Yard:
                    result = value * 0.00056818;
                    break;
                case UnitsOfMeasure.NauticalMile:
                    result = value * 1.15077945;
                    break;
            }
            return result;
        }

        public static double ToFoot(this double value, UnitsOfMeasure unit)
        {
            var result = 0.0;
            switch (unit)
            {
                case UnitsOfMeasure.Foot:
                    result = value;
                    break;
                case UnitsOfMeasure.Kilometer:
                    result = value * 3280.8399;
                    break;
                case UnitsOfMeasure.Meter:
                    result = value * 3.2808399;
                    break;
                case UnitsOfMeasure.Mile:
                    result = value * 5280.0;
                    break;
                case UnitsOfMeasure.Yard:
                    result = value * 3.0;
                    break;
                case UnitsOfMeasure.NauticalMile:
                    result = value * 6076.11549;
                    break;
            }
            return result;
        }

        public static double ToKilometer(this double value, UnitsOfMeasure unit)
        {
            var result = 0.0;
            switch (unit)
            {
                case UnitsOfMeasure.Foot:
                    result = value * 0.0003048;
                    break;
                case UnitsOfMeasure.Kilometer:
                    result = value;
                    break;
                case UnitsOfMeasure.Meter:
                    result = value * 0.001;
                    break;
                case UnitsOfMeasure.Mile:
                    result = value * 1.609344;
                    break;
                case UnitsOfMeasure.Yard:
                    result = value * 0.0009144;
                    break;
                case UnitsOfMeasure.NauticalMile:
                    result = value * 1.852;
                    break;
            }
            return result;
        }

        public static double ToMeter(this double value, UnitsOfMeasure unit)
        {
            var result = 0.0;
            switch (unit)
            {
                case UnitsOfMeasure.Foot:
                    result = value * 0.3048;
                    break;
                case UnitsOfMeasure.Kilometer:
                    result = value * 1000;
                    break;
                case UnitsOfMeasure.Meter:
                    result = value;
                    break;
                case UnitsOfMeasure.Mile:
                    result = value * 1609.344;
                    break;
                case UnitsOfMeasure.Yard:
                    result = value * 0.9144;
                    break;
                case UnitsOfMeasure.NauticalMile:
                    result = value * 1852;
                    break;
            }
            return result;
        }

        public static double ToYard(this double value, UnitsOfMeasure unit)
        {
            var result = 0.0;
            switch (unit)
            {
                case UnitsOfMeasure.Foot:
                    result = value * 0.33333333;
                    break;
                case UnitsOfMeasure.Kilometer:
                    result = value * 1093.6133;
                    break;
                case UnitsOfMeasure.Meter:
                    result = value * 1.0936133;
                    break;
                case UnitsOfMeasure.Mile:
                    result = value * 1760;
                    break;
                case UnitsOfMeasure.Yard:
                    result = value;
                    break;
                case UnitsOfMeasure.NauticalMile:
                    result = value * 2025.37183;
                    break;
            }
            return result;
        }
    }
}
