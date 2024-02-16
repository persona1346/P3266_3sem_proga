using Lab3.Presenter;

namespace Lab3.AppContext;

public interface IDataMngr
{
    HashSet<DateData> LoadDates();
    void SaveDates(CalendarSet calendar);
}