using CalendarLab.AppContext;
using CalendarLab.Presenter;
using CalendarLab.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CalendarContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CalendarDb")));

builder.Services.AddTransient<IRepos, Repos>();
builder.Services.AddTransient<IDataMngr, DatabaseLoader>();
builder.Services.AddTransient<ICalendar, CalendarSet>();


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();