
namespace RefplusWebtools.Tools
{
    class Conversion
    {
        public static decimal Celcius_Fahrenheit(decimal decValueToConvert)
        {
            return (9m / 5m) * decValueToConvert + 32m;
        }

        public static decimal Celcius_Kelvin(decimal decValueToConvert)
        {
            return decValueToConvert + 273.15m;
        }

        public static decimal Fahrenheit_Celcius(decimal decValueToConvert)
        {
            return (5m / 9m) * (decValueToConvert - 32m);
        }

        public static decimal Fahrenheit_Kelvin(decimal decValueToConvert)
        {
            return (decValueToConvert + 459.67m) / 1.8m;
        }

        public static decimal Kelvin_Celcius(decimal decValueToConvert)
        {
            return decValueToConvert - 273.15m;
        }

        public static decimal Kelvin_Fahrenheit(decimal decValueToConvert)
        {
            return decValueToConvert * 1.8m - 459.67m;
        }

        public static decimal Inches_Millimiters(decimal decValueToConvert)
        {
            return decValueToConvert * 25.4m;
        }

        public static decimal Millimiters_Inches(decimal decValueToConvert)
        {
            return decValueToConvert * 0.0394m;
        }

        public static decimal Inches_Centimeters(decimal decValueToConvert)
        {
            return decValueToConvert * 2.54m;
        }

        public static decimal Inches_Meters(decimal decValueToConvert)
        {
            return decValueToConvert * 0.0254m;
        }

        public static decimal Inches_Feet(decimal decValueToConvert)
        {
            return decValueToConvert / 12m;
        }

        public static decimal Centimeters_Inches(decimal decValueToConvert)
        {
            return decValueToConvert * 0.3937m;
        }

        public static decimal Feet_Meters(decimal decValueToConvert)
        {
            return decValueToConvert * 0.3048m;
        }

        public static decimal Feet_Inches(decimal decValueToConvert)
        {
            return decValueToConvert * 12m;
        }

        public static decimal Meters_Feet(decimal decValueToConvert)
        {
            return decValueToConvert * 3.281m;
        }

        public static decimal Meters_Inches(decimal decValueToConvert)
        {
            return decValueToConvert * 39.37m;
        }

        public static decimal Miles_Kilometers(decimal decValueToConvert)
        {
            return decValueToConvert * 1.609m;
        }

        public static decimal Kilometers_Miles(decimal decValueToConvert)
        {
            return decValueToConvert * 0.6214m;
        }

        public static decimal SquareInches_SquareCentimeters(decimal decValueToConvert)
        {
            return decValueToConvert * 6.452m;
        }

        public static decimal SquareCentimeters_SquareInches(decimal decValueToConvert)
        {
            return decValueToConvert * 0.155m;
        }

        public static decimal SquareMeters_SquareFeet(decimal decValueToConvert)
        {
            return decValueToConvert * 10.76m;
        }

        public static decimal SquareFeet_SquareMeters(decimal decValueToConvert)
        {
            return decValueToConvert * 0.0929m;
        }

        public static decimal SquareMiles_SquareKilometers(decimal decValueToConvert)
        {
            return decValueToConvert * 2.589m;
        }

        public static decimal SquareKilometers_SquareMiles(decimal decValueToConvert)
        {
            return decValueToConvert * 0.3861m;
        }

        public static decimal CubicInches_CubicCentimeters(decimal decValueToConvert)
        {
            return decValueToConvert * 16.39m;
        }

        public static decimal CubicCentimeters_CubicInches(decimal decValueToConvert)
        {
            return decValueToConvert * 0.06102m;
        }

        public static decimal CubicFeet_CubicMeters(decimal decValueToConvert)
        {
            return decValueToConvert * 0.02832m;
        }

        public static decimal CubicMeters_CubicFeet(decimal decValueToConvert)
        {
            return decValueToConvert * 35.315m;
        }

        public static decimal CubicInches_Liters(decimal decValueToConvert)
        {
            return decValueToConvert * 0.01639m;
        }

        public static decimal Liters_CubicInches(decimal decValueToConvert)
        {
            return decValueToConvert * 61.03m;
        }

        public static decimal Pints_Liters(decimal decValueToConvert)
        {
            return decValueToConvert * 0.5682m;
        }

        public static decimal Liters_Pints(decimal decValueToConvert)
        {
            return decValueToConvert * 1.76m;
        }

        public static decimal USPints_Liters(decimal decValueToConvert)
        {
            return decValueToConvert * 0.47311m;
        }

        public static decimal Liters_USPints(decimal decValueToConvert)
        {
            return decValueToConvert * 2.114m;
        }

        public static decimal USGallons_Liters(decimal decValueToConvert)
        {
            return decValueToConvert * 3.785m;
        }

        public static decimal Liters_USGallons(decimal decValueToConvert)
        {
            return decValueToConvert * 0.2642m;
        }

        public static decimal Gallons_Liters(decimal decValueToConvert)
        {
            return decValueToConvert * 4.546m;
        }

        public static decimal Liters_Gallons(decimal decValueToConvert)
        {
            return decValueToConvert * 0.22m;
        }

        public static decimal Pounds_Kilograms(decimal decValueToConvert)
        {
            return decValueToConvert * 0.4536m;
        }

        public static decimal Kilograms_Pounds(decimal decValueToConvert)
        {
            return decValueToConvert * 2.205m;
        }

        public static decimal Tons_Kilograms(decimal decValueToConvert)
        {
            return decValueToConvert * 1016.05m;
        }

        public static decimal Kilograms_Tons(decimal decValueToConvert)
        {
            return decValueToConvert * 0.0009842m;
        }

        public static decimal Btu_Tons(decimal decValueToConvert)
        {
            return decValueToConvert / 12000m;
        }

        public static decimal Tons_Btu(decimal decValueToConvert)
        {
            return decValueToConvert * 12000m;
        }

        public static decimal Btu_Mbh(decimal decValueToConvert)
        {
            return decValueToConvert / 1000m;
        }

        public static decimal Mbh_Btu(decimal decValueToConvert)
        {
            return decValueToConvert * 1000m;
        }

        public static decimal Mbh_Tons(decimal decValueToConvert)
        {
            return decValueToConvert / 12m;
        }

        public static decimal Tons_Mbh(decimal decValueToConvert)
        {
            return decValueToConvert * 12m;
        }

        public static decimal Btu_Joules(decimal decValueToConvert)
        {
            return decValueToConvert * 0.0009478171m;
        }

        public static decimal Joules_Btu(decimal decValueToConvert)
        {
            return decValueToConvert / 0.0009478171m;
        }

        public static decimal Btu_Calories(decimal decValueToConvert)
        {
            return decValueToConvert * 251.9958m;
        }

        public static decimal Calories_Btu(decimal decValueToConvert)
        {
            return decValueToConvert / 251.9958m;
        }

        public static decimal Hp_Kilowatts(decimal decValueToConvert)
        {
            return decValueToConvert * 0.7457m;
        }

        public static decimal Kilowatts_Hp(decimal decValueToConvert)
        {
            return decValueToConvert / 0.7457m;
        }

        public static decimal Atm_Bar(decimal decValueToConvert)
        {
            return decValueToConvert * 1.01325m;
        }

        public static decimal Bar_Atm(decimal decValueToConvert)
        {
            return decValueToConvert / 1.01325m;
        }

        public static decimal Atm_Inhg(decimal decValueToConvert)
        {
            return decValueToConvert * 29.92126m;
        }

        public static decimal Inhg_Atm(decimal decValueToConvert)
        {
            return decValueToConvert / 29.92126m;
        }

        public static decimal Atm_Kpa(decimal decValueToConvert)
        {
            return decValueToConvert * 101.325m;
        }

        public static decimal Kpa_Atm(decimal decValueToConvert)
        {
            return decValueToConvert / 101.325m;
        }

        public static decimal Atm_Mmhg(decimal decValueToConvert)
        {
            return decValueToConvert * 760m;
        }

        public static decimal Mmhg_Atm(decimal decValueToConvert)
        {
            return decValueToConvert / 760m;
        }

        public static decimal Psi_Atm(decimal decValueToConvert)
        {
            return decValueToConvert * 0.0680456m;
        }

        public static decimal Atm_Psi(decimal decValueToConvert)
        {
            return decValueToConvert / 0.0680456m;
        }

        public static decimal Psi_Mmhg(decimal decValueToConvert)
        {
            return decValueToConvert * 2.036021m;
        }

        public static decimal Mmhg_Psi(decimal decValueToConvert)
        {
            return decValueToConvert / 2.036021m;
        }

        //this is the list of all possible convertion of the class
        public static string[] ListOfPossibleConversions()
        {
            var strListOfPossibleConversions = new[] 
            { 
                "atm,bar"
                ,"atm,inHg"
                ,"atm,kPa"
                ,"atm,mmHg"
                ,"atm,psi"
                ,"bar,atm"
                ,"btu,Calories"
                ,"btu,Joules"
                ,"btu,Mbh"
                ,"btu,Tons"
                ,"Calories,btu"
                ,"Celcius,Fahrenheit"
                ,"Celcius,Kelvin"
                ,"Centimeters,Inches"
                ,"Cubic Centimeters,Cubic Inches"
                ,"Cubic Feet,Cubic Meters"
                ,"Cubic Inches,Cubic Centimeters"
                ,"Cubic Inches,Liters"
                ,"Cubic Meters,Cubic Feet"
                ,"Fahrenheit,Celcius"
                ,"Fahrenheit,Kelvin"
                ,"Feet,Inches"
                ,"Feet,Meters"
                ,"Gallons,Liters"
                ,"hp,kW"
                ,"Inches,Centimeters"
                ,"Inches,Feet"
                ,"Inches,Meters"
                ,"Inches,Millimiters"
                ,"inHg,atm"
                ,"Joules,btu"
                ,"Kelvin,Celcius"
                ,"Kelvin,Fahrenheit"
                ,"Kilograms,Pounds"
                ,"Kilograms,Tons"
                ,"Kilometers,Miles"
                ,"kW,hp"
                ,"kPa,atm"
                ,"Liters,Cubic Inches"
                ,"Liters,Gallons"
                ,"Liters,Pints"
                ,"Liters,US Gallons"
                ,"Liters,US Pints"
                ,"Mbh,btu"
                ,"Mbh,Tons"
                ,"Meters,Feet"
                ,"Meters,Inches"
                ,"Miles,Kilometers"
                ,"Millimiters,Inches"
                ,"mmHg,atm"
                ,"mmHg,psi"
                ,"Pints,Liters"
                ,"Pounds,Kilograms"
                ,"psi,atm"
                ,"psi,mmHg"
                ,"Square Centimeters,Square Inches"
                ,"Square Feet, Square Meters"
                ,"Square Inches,Square Centimeters"
                ,"Square Kilometers,Square Miles"
                ,"Square Meters,Square Feet"
                ,"Square Miles,Square Kilometers"
            };

            return strListOfPossibleConversions;
        }

        //convert to the format spcified
        public static decimal Convert(string strConversionFormat, decimal decValueToConvert)
        {
            switch (strConversionFormat)
            {
                case "atm,bar":
                    return Atm_Bar(decValueToConvert);

                case "atm,inHg":
                    return Atm_Inhg(decValueToConvert);

                case "atm,kPa":
                    return Atm_Kpa(decValueToConvert);

                case "atm,mmHg":
                    return Atm_Mmhg(decValueToConvert);

                case "atm,psi":
                    return Atm_Psi(decValueToConvert);

                case "bar,atm":
                    return Bar_Atm(decValueToConvert);

                case "btu,Calories":
                    return Btu_Calories(decValueToConvert);

                case "btu,Joules":
                    return Btu_Joules(decValueToConvert);

                case "btu,Mbh":
                    return Btu_Mbh(decValueToConvert);

                case "btu,Tons":
                    return Btu_Tons(decValueToConvert);

                case "Calories,btu":
                    return Calories_Btu(decValueToConvert);

                case "Celcius,Fahrenheit":
                    return Celcius_Fahrenheit(decValueToConvert);

                case "Celcius,Kelvin":
                    return Celcius_Kelvin(decValueToConvert);

                case "Centimeters,Inches":
                    return Centimeters_Inches(decValueToConvert);

                case "Cubic Centimeters,Cubic Inches":
                    return CubicCentimeters_CubicInches(decValueToConvert);

                case "Cubic Feet,Cubic Meters":
                    return CubicFeet_CubicMeters(decValueToConvert);

                case "Cubic Inches,Cubic Centimeters":
                    return CubicInches_CubicCentimeters(decValueToConvert);

                case "Cubic Inches,Liters":
                    return CubicInches_Liters(decValueToConvert);

                case "Cubic Meters,Cubic Feet":
                    return CubicMeters_CubicFeet(decValueToConvert);

                case "Fahrenheit,Celcius":
                    return Fahrenheit_Celcius(decValueToConvert);

                case "Fahrenheit,Kelvin":
                    return Fahrenheit_Kelvin(decValueToConvert);

                case "Feet,Meters":
                    return Feet_Meters(decValueToConvert);

                case "Feet,Inches":
                    return Feet_Inches(decValueToConvert);

                case "Gallons,Liters":
                    return Gallons_Liters(decValueToConvert);

                case "hp,kW":
                    return Hp_Kilowatts(decValueToConvert);

                case "Inches,Centimeters":
                    return Inches_Centimeters(decValueToConvert);

                case "Inches,Feet":
                    return Inches_Feet(decValueToConvert);

                case "Inches,Meters":
                    return Inches_Meters(decValueToConvert);

                case "Inches,Millimiters":
                    return Inches_Millimiters(decValueToConvert);

                case "inHg,atm":
                    return Inhg_Atm(decValueToConvert);

                case "Joules,btu":
                    return Joules_Btu(decValueToConvert);

                case "Kelvin,Celcius":
                    return Kelvin_Celcius(decValueToConvert);

                case "Kelvin,Fahrenheit":
                    return Kelvin_Fahrenheit(decValueToConvert);

                case "Kilograms,Pounds":
                    return Kilograms_Pounds(decValueToConvert);

                case "Kilograms,Tons":
                    return Kilograms_Tons(decValueToConvert);

                case "Kilometers,Miles":
                    return Kilometers_Miles(decValueToConvert);

                case "kW,hp":
                    return Kilowatts_Hp(decValueToConvert);

                case "kPa,atm":
                    return Kpa_Atm(decValueToConvert);

                case "Liters,Cubic Inches":
                    return Liters_CubicInches(decValueToConvert);

                case "Liters,Gallons":
                    return Liters_Gallons(decValueToConvert);

                case "Liters,Pints":
                    return Liters_Pints(decValueToConvert);

                case "Liters,US Gallons":
                    return Liters_USGallons(decValueToConvert);

                case "Liters,US Pints":
                    return Liters_USPints(decValueToConvert);

                case "Mbh,btu":
                    return Mbh_Btu(decValueToConvert);

                case "Mbh,Tons":
                    return Mbh_Tons(decValueToConvert);

                case "Meters,Feet":
                    return Meters_Feet(decValueToConvert);

                case "Meters,Inches":
                    return Meters_Inches(decValueToConvert);

                case "Miles,Kilometers":
                    return Miles_Kilometers(decValueToConvert);

                case "Millimiters,Inches":
                    return Millimiters_Inches(decValueToConvert);

                case "mmHg,atm":
                    return Mmhg_Atm(decValueToConvert);

                case "mmHg,psi":
                    return Mmhg_Psi(decValueToConvert);

                case "Pints,Liters":
                    return Pints_Liters(decValueToConvert);

                case "Pounds,Kilograms":
                    return Pounds_Kilograms(decValueToConvert);

                case "psi,atm":
                    return Psi_Atm(decValueToConvert);

                case "psi,mmHg":
                    return Psi_Mmhg(decValueToConvert);

                case "Square Centimeters,Square Inches":
                    return SquareCentimeters_SquareInches(decValueToConvert);

                case "Square Feet, Square Meters":
                    return SquareFeet_SquareMeters(decValueToConvert);

                case "Square Inches,Square Centimeters":
                    return SquareInches_SquareCentimeters(decValueToConvert);

                case "Square Kilometers,Square Miles":
                    return SquareKilometers_SquareMiles(decValueToConvert);

                case "Square Meters,Square Feet":
                    return SquareMeters_SquareFeet(decValueToConvert);

                case "Square Miles,Square Kilometers":
                    return SquareMiles_SquareKilometers(decValueToConvert);

                default:
                    return 0m;
            }
        }
    }
}
