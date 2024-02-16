namespace Lab3.Presenter;

public class DateData
{
    public int year { get; set; }
    public int month { get; set; }
    public int day { get; set; }
    public bool IsLeapYear { get; set; }

    public DateData(DateTime date)
    {
        this.year = date.Year;
        this.month = date.Month;
        this.day = date.Day;
        IsLeapYear = DateTime.IsLeapYear(year);
    }
    
    public DateData(string year, string month, string day, bool IsLeapYear)
    {
        this.year = Convert.ToInt32(year);
        this.month = Convert.ToInt32(month);
        this.day = Convert.ToInt32(day);
        this.IsLeapYear = IsLeapYear;
    }

    public override string ToString()
    {
        return $"{day}.{month}.{year}";
    }
}