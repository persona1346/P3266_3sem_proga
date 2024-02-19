using System.Globalization;
using Lab2.Presenter;
using Xunit;
namespace CalendarTests;
public class UnitTest1
{
    [Fact]
    public void IsLeapYear_ValidYear_ReturnsTrue()
    {
        // Arrange
        CalendarSet CalendarSet = new CalendarSet();
        int leapYear = 2024;

        // Act
        // Act 
        bool result = CalendarSet.IsLeapYear(new DateTime(leapYear, 1, 1));

        // Assert
        Assert.True(result);
    }
    [Fact]
    public void IsLeapYear_InvalidYear_ReturnsFalse()
    {
        // Arrange
        CalendarSet CalendarSet = new CalendarSet();
        int nonLeapYear = 2023;
        // Act
        bool result = CalendarSet.IsLeapYear(new DateTime(nonLeapYear, 1, 1));
        // Assert
        Assert.False(result);
    }
    [Fact]
    public void CalculateDays_ValidDates_ReturnsCorrectInterval()
    {
        // Arrange
        CalendarSet CalendarSet = new CalendarSet();
        DateTime date1 = new DateTime(2022, 1, 1);
        DateTime date2 = new DateTime(2022, 1, 10);
        // Act
        int result = CalendarSet.CalculateDays(date1, date2);
        // Assert
        Assert.Equal(9, result);
    }
    [Fact]
    public void GetWeekDay_ValidDate_ReturnsCorrectDayOfWeek()
    {
        // Arrange
        CalendarSet CalendarSet = new CalendarSet();
        DateTime date = new DateTime(2022, 1, 1);
        // Act
        string result = CalendarSet.GetWeekDay(date);
        // Assert
        Assert.Equal("Saturday", result);
    }
    
}