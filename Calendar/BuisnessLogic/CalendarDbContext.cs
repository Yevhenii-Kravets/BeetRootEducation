using Microsoft.EntityFrameworkCore;
using Models;
using Task = Models.Task;

namespace BuisnessLogic
{
    public class CalendarDbContext : DbContext
    {
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<EventTheme> Themes { get; set; }
        public virtual DbSet<EventRepeat> Repeats { get; set; }

        public CalendarDbContext(DbContextOptions<CalendarDbContext> options) : base(options)
        {

        }
    }
}