using CalendarLab.Presenter;

namespace CalendarLab.AppContext;

public interface IDataMngr
{
    HashSet<DateData> LoadDates();
    void SaveDates(CalendarSet calendar);
}