using BuisnessLogic;
using BuisnessLogic.Services;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;
using Task = Models.Task;

namespace Calendar.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private readonly TaskServices _services;

        public TaskController(ILogger<TaskController> logger, CalendarDbContext calendar)
        {
            _logger = logger;
            _services = new TaskServices(calendar);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new TaskGetRequestModel();
            var tasks = _services.GetAllTasks();

            model.Tasks = tasks.Select(task => new TaskGetRequestModel.TaskModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Date = task.Date,
                Color = task.Color
            });

            return Ok(model.Tasks);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var task = _services.GetAllTasks().FirstOrDefault(t => t.Id == id);

            var result = new TaskGetRequestModel.TaskModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Date = task.Date,
                Color = task.Color
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TaskPostRequestModel.TaskModel task)
        {
            if (task != null)
            {
                if (string.IsNullOrWhiteSpace(task.Title))
                    return Json(new { success = false });

                _services.CreateTask(new Task
                {
                    Id = Guid.NewGuid(),
                    Title = task.Title,
                    Description = task.Description,
                    Color = task.Color,
                    Date = task.Date
                });

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public IActionResult Edit(Guid id, [FromBody] TaskPostRequestModel.TaskModel task)
        {
            if (task != null)
            {
                if (string.IsNullOrWhiteSpace(task.Title))
                    return Json(new { success = false });

                _services.UpdateTask(new Task
                {
                    Id = id,
                    Title = task.Title,
                    Description = task.Description,
                    Date = task.Date,
                    Color = task.Color
                });
                return Json(new { success = true });

            }
            else
                return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            if (_services.DeleteTask(id))
                return Json(new { success = true });
            else
                return Json(new { success = false });
        }
    }
}
