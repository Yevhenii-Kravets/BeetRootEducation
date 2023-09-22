using Microsoft.EntityFrameworkCore;
using Models;
using Task = Models.Task;
using Theme = Models.Theme;

namespace BuisnessLogic
{
    public class CalendarDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Repeat> Repeats { get; set; }

        public CalendarDbContext(DbContextOptions<CalendarDbContext> options) : base(options)
        {
        }
    }
}