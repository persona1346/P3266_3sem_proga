using System;
using System.Collections.ObjectModel;
using CalendarLab.AppContext;
using ReactiveUI;

namespace CalendarGUI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _year = "2024";
    private string _month = "12";
    private string _day = "31";
    
    private CalendarContext _context;
    private DatabaseLoader _database;
    
    public ObservableCollection<DateDataDto> Dates { get; set; } = new ObservableCollection<DateDataDto>();
    
    public string Year
    {
        get => _year;
        set => this.RaiseAndSetIfChanged(ref _year, value);
    }
    
    public string Month
    {
        get => _month;
        set => this.RaiseAndSetIfChanged(ref _month, value);
    }
    
    public string Day
    {
        get => _day;
        set => this.RaiseAndSetIfChanged(ref _day, value);
    }
    
    public MainWindowViewModel()
    {
        _context = new CalendarContext();
        _database = new DatabaseLoader(_context);
    }

    public void AddDate()
    {
        var date = new DateDataDto
        {
            year = Year,
            month = Month,
            day = Day,
            IsLeapYear = DateTime.IsLeapYear(Convert.ToInt32(Year))
        };
        Dates.Add(date);
        _database.SaveDates(Dates);
    }

}