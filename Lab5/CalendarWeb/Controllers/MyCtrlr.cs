using CalendarLab.AppContext;
using CalendarLab.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CalendarWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class MyCtrlr
{
    private readonly IRepos _repos;

    public MyCtrlr(IRepos repos)
    {
        _repos = repos;
    }
    
    [HttpGet] [Route("/check-leap-year")]
    public async Task<bool> IsLeapYearAsync([FromQuery] DateTime dateTime)
    {
        return await _repos.IsLeapYearAsync(dateTime);

    }

    [HttpGet]
    [Route("/calculate-days")]
    public Task<int> CalculateDaysAsync([FromQuery] DateTime dateTime1, DateTime dateTime2)
    {
        return _repos.CalculateDaysAsync(dateTime1, dateTime2);
    }

    [HttpGet]
    [Route("/get-week-day")]
    public Task<string> GetWeekDayAsync([FromQuery] DateTime dateTime)
    {
        return _repos.GetWeekDayAsync(dateTime);
    }
    
    [HttpGet]
    [Route("/show-all-dates")]
    public Task<List<DateDataDto>> ShowAllDatesAsync()
    {
        return _repos.ShowAllDatesAsync();
    }
}