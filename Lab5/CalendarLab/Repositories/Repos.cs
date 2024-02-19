using CalendarLab.AppContext;
using CalendarLab.Presenter;
using Microsoft.EntityFrameworkCore;

namespace CalendarLab.Repositories;

public class Repos : IRepos
{
    private readonly CalendarContext _context;

    public Repos(CalendarContext context)
    {
        _context = context;
    }

    public async Task<bool> IsLeapYearAsync(DateTime date)
    {
        await _context.Dates.AddAsync(new DateDataDto(new DateData(date)));
        return DateTime.IsLeapYear(date.Year);
    }

    public async Task<int> CalculateDaysAsync(DateTime date1, DateTime date2)
    {
        await _context.Dates.AddAsync(new DateDataDto(new DateData(date1)));
        await _context.Dates.AddAsync(new DateDataDto(new DateData(date2)));
        
        TimeSpan duration = date2 - date1;
        return duration.Days;
    }

    public async Task<string> GetWeekDayAsync(DateTime date)
    {
        await _context.Dates.AddAsync(new DateDataDto(new DateData(date)));
        return date.DayOfWeek.ToString();
    }

    public async Task<List<DateDataDto>> ShowAllDatesAsync()
    {
        return await _context.Dates.ToListAsync();
    }
}