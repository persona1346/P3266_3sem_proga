using CalendarLab.Presenter;

namespace CalendarLab.AppContext;

public class DateDataDto
{
    public ulong id { get; set; }
    public string year { get; set; }
    public string month { get; set; }
    public string day { get; set; }
    public bool IsLeapYear { get; set; }
    
    public DateDataDto(){}

    public DateDataDto(DateData date)
    {
        year = date.year.ToString();
        month = date.month.ToString();
        day = date.day.ToString();
        IsLeapYear = date.IsLeapYear;
    }
}