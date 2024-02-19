using CalendarLab.AppContext;
using CalendarLab.Presenter;
using Moq;
using Xunit;

namespace CalendarTests;

public class UnitTest1
{
    [Fact]
    public void IsLeapYear()
    {
        var moq = new Mock<IDataMngr>();
        moq.Setup(r => r.LoadDates()).Returns(new HashSet<DateData>());

        var dCalendarSet = new CalendarSet(moq.Object);

        var date = DateTime.Now;
        dCalendarSet.IsLeapYear(date);
        var datefromcalend = dCalendarSet.dates.First();
        
        Assert.Equal(datefromcalend.year, date.Year);
        
    }

    [Fact]
    public void AddContact_DbHasThis()
    {
        var moq = new Mock<IDataMngr>();
        moq.Setup(r => r.LoadDates()).Returns(new HashSet<DateData>());

        var dCalendarSet = new CalendarSet(moq.Object);

        var date = DateTime.Now;
        dCalendarSet.GetWeekDay(date);
        var datefromcalend = dCalendarSet.dates.First();
        
        Assert.Equal(datefromcalend.year, date.Year);

    }
    
}