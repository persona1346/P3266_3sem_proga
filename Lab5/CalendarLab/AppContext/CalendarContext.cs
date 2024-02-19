using Microsoft.EntityFrameworkCore;

namespace CalendarLab.AppContext;

public class CalendarContext : DbContext
{
    public DbSet<DateDataDto> Dates { get; set; }
    
    public CalendarContext(DbContextOptions<CalendarContext> options):base(options)
    {
        Database.EnsureCreated();
    }

    public CalendarContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=CalendarDB.db");
}