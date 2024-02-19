namespace CalendarLab.Presenter;

public interface ICalendar
{
    bool IsLeapYear(DateTime date);
    int CalculateDays(DateTime date1, DateTime date2);
    string GetWeekDay(DateTime date);
    void ShowAllDates();
}