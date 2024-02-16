namespace Lab2.Presenter
{
    public class CalendarSet : ICalendar
    {
        private HashSet<DateData> dates;
        public CalendarSet()
        {
            dates = new HashSet<DateData>();
        }
        public bool IsLeapYear(DateTime date)
        {
            var existingDate = AddDateToCalendar(date);
            return existingDate.IsLeapYear;
        }
        public int CalculateDays(DateTime date1, DateTime date2)
        {
            AddDateToCalendar(date1);
            AddDateToCalendar(date2);
            TimeSpan duration = date2 - date1;
            return duration.Days;
        }
        public string GetWeekDay(DateTime date)
        {
            AddDateToCalendar(date);
            return date.DayOfWeek.ToString();
        }
        
        public void ShowAllDates()
        {
            foreach (var date in dates)
            {
                Console.WriteLine(date);
            }
        }
        private DateData AddDateToCalendar(DateTime date)
        {
            var d = new DateData(date);
            if (!dates.Contains(d))
            {
                dates.Add(d);
            }
            return d;
        }
    }
}