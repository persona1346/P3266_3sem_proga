using CalendarLab.AppContext;

namespace CalendarLab.Repositories;

public interface IRepos
{
    Task<bool> IsLeapYearAsync(DateTime date);
    Task<int> CalculateDaysAsync(DateTime date1, DateTime date2);
    Task<string> GetWeekDayAsync(DateTime date);
    Task<List<DateDataDto>> ShowAllDatesAsync();
}