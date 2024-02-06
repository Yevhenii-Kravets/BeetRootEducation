using BuisnessLogic.Interfaces;
using Microsoft.Extensions.Logging;
using Models;
using Task = Models.Task;

namespace BuisnessLogic.Services
{
    public class TaskService : IServiceItem<Task>
    {
        private readonly CalendarDbContext _calendar;

        public TaskService(CalendarDbContext calendar)
        {
            _calendar = calendar;
        }

        public IEnumerable<Task> GetInRange(DateTime start, DateTime end)
        {
            return _calendar.Tasks
                .Where(task => task.Date <= end && task.Date >= start)
                .ToList();
        }

        public IEnumerable<Task> GetAll()
        {
            return _calendar.Tasks.ToList();
        }

        public Guid Create(Task t)
        {
            if (_calendar.Tasks.FirstOrDefault(ts => ts.Id == t.Id) != null)
            {
                throw new InvalidOperationException($"Creation failed. Item with ID {t.Id} is found.");

            }

                _calendar.Tasks.Add(t);

            var result = _calendar.SaveChanges();

            return t.Id;
        }


        public Guid Update(Task t)
        {
            var @task = _calendar.Tasks.FirstOrDefault(ts => ts.Id == t.Id);

            if (@task == null)
                throw new InvalidOperationException($"Update failed. Item with ID {t.Id} not found.");

            @task.Title = t.Title;
            @task.Description = t.Description;
            @task.Date = t.Date;
            @task.Color = t.Color;

            var result = _calendar.SaveChanges();

            return t.Id;
        }


        public Guid Delete(Guid id)
        {
            var @task = _calendar.Tasks.FirstOrDefault(task => task.Id == id);

            if (@task == null)
                throw new InvalidOperationException($"Delete failed. Item with ID {id} not found.");

            _calendar.Tasks.Remove(@task);

            var result = _calendar.SaveChanges();

            return id;
        }

        public Task Details(Guid id)
        {
            var task = _calendar.Tasks.FirstOrDefault(e => e.Id == id);

            if (task == null)
                throw new InvalidOperationException($"Error. Item with ID {id} not found.");

            return task;
        }

    }
}
