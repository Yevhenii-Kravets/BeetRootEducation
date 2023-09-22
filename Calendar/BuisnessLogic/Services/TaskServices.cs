using Models;
using Task = Models.Task;

namespace BuisnessLogic.Services
{
    public class TaskServices
    {
        private readonly CalendarDbContext _calendar;

        public TaskServices(CalendarDbContext calendar)
        {
            _calendar = calendar;
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _calendar.Tasks.ToList();
        }
        public bool CreateTask(Task t)
        {
            _calendar.Tasks.Add(t);

            var result = _calendar.SaveChanges();

            return true;
        }


        public bool UpdateTask(Task t)
        {
            var taskToUpdate = _calendar.Tasks.FirstOrDefault(task => task.Id == t.Id);

            taskToUpdate.Title = t.Title;
            taskToUpdate.Description = t.Description;
            taskToUpdate.Date = t.Date;
            taskToUpdate.Color = t.Color;

            var result = _calendar.SaveChanges();

            return true;
        }


        public bool DeleteTask(Guid id)
        {
            var taskToDelete = _calendar.Tasks.FirstOrDefault(task => task.Id == id);

            if (taskToDelete != null)
            {
                _calendar.Tasks.Remove(taskToDelete);

                var result = _calendar.SaveChanges();
                return true;
            }
            else
                return false;

        }
    }
}
