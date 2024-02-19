namespace Lab2.Presenter;
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
    public override string ToString()
    {
        return $"{day}.{month}.{year}";
    }
}