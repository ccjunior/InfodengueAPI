using System.Globalization;

namespace InfodengueAPI.Business.Converter
{
    public static class DateConverter
    {
        public static int GetWeekOfYear(DateTime date)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            Calendar calendar = culture.Calendar;
            int weekNumber = calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNumber;
        }
    }
}
