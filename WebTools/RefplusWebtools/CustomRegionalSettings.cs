using System;

namespace RefplusWebtools
{
    public class CustomRegionalSettings
    {
        public static void UseDectronFormat()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US")
            {
                NumberFormat =
                {
                    CurrencyDecimalSeparator = ".",
                    CurrencyGroupSeparator = "'",
                    CurrencyGroupSizes = new[] {3},
                    CurrencyNegativePattern = 0,
                    CurrencyPositivePattern = 0,
                    CurrencySymbol = "$",
                    DigitSubstitution = System.Globalization.DigitShapes.None,
                    NaNSymbol = "NaN",
                    NativeDigits = new[] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"},
                    NegativeInfinitySymbol = "-Infinity",
                    NegativeSign = "-",
                    NumberDecimalDigits = 2,
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = ",",
                    NumberGroupSizes = new[] {3},
                    NumberNegativePattern = 1,
                    PercentDecimalDigits = 2,
                    PercentDecimalSeparator = ".",
                    PercentGroupSeparator = ",",
                    PercentGroupSizes = new[] {3},
                    PercentNegativePattern = 0,
                    PercentPositivePattern = 0,
                    PercentSymbol = "%",
                    PerMilleSymbol = "‰",
                    PositiveInfinitySymbol = "Infinity",
                    PositiveSign = "+"
                },
                DateTimeFormat =
                {
                    AbbreviatedDayNames = new[] {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"},
                    AbbreviatedMonthGenitiveNames =
                        new[]
                        {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", ""},
                    AbbreviatedMonthNames =
                        new[]
                        {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", ""},
                    AMDesignator = "AM",
                    Calendar = {TwoDigitYearMax = 2029},
                    CalendarWeekRule = System.Globalization.CalendarWeekRule.FirstDay,
                    DateSeparator = "/",
                    DayNames =
                        new[] {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"},
                    FirstDayOfWeek = DayOfWeek.Sunday,
                    FullDateTimePattern = "dddd, MMMM dd, yyyy h:mm:ss tt",
                    LongDatePattern = "dddd, MMMMdd, yyyy",
                    LongTimePattern = "h:mm:ss tt",
                    MonthDayPattern = "MMMM dd",
                    MonthGenitiveNames =
                        new[]
                        {
                            "January", "February", "March", "April", "May", "June", "July", "August", "September",
                            "October", "November", "December", ""
                        },
                    MonthNames =
                        new[]
                        {
                            "January", "February", "March", "April", "May", "June", "July", "August", "September",
                            "October", "November", "December", ""
                        },
                    PMDesignator = "PM",
                    ShortDatePattern = "M/d/yyyy",
                    ShortestDayNames = new[] {"Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"},
                    ShortTimePattern = "h:mm tt",
                    TimeSeparator = ":",
                    YearMonthPattern = "MMMM, yyyy"
                }
            };
        }
    }
}
