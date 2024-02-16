using Lab3.Presenter;

namespace Lab3.AppContext;

public class DatabaseLoader : IDataMngr
{
    private readonly CalendarContext _context;

    public DatabaseLoader(CalendarContext context)
    {
        _context = context;
    }

    public HashSet<DateData> LoadDates()
    {
        var dates = _context.Dates.ToHashSet();

        return dates
            .Select(dataDto => new DateData(dataDto.year, dataDto.month, dataDto.day, dataDto.IsLeapYear))
            .GroupBy(c => c.year)
            .Select(group => group.First()) 
            .ToHashSet();
    }

    public void SaveDates(CalendarSet calendar)
    {
        _context.Dates.RemoveRange(_context.Dates);
        _context.SaveChanges();

        var _contacts = calendar.dates;

        _context.Dates.AddRangeAsync(_contacts.Select(x => ConvertToDTO(x)).ToHashSet());
        _context.SaveChanges();
    }

    private DateDataDto ConvertToDTO(DateData t)
    {
        var res = new DateDataDto(t);
        return res;
    }
}