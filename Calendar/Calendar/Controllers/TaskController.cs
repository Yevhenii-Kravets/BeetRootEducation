using BuisnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Task = Models.Task;

namespace Calendar.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private readonly IServiceItem<Task> _service;

        public TaskController(ILogger<TaskController> logger, IServiceItem<Task> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        public IActionResult Range(DateTime startDate, DateTime endDate) 
        {
            var tasks = _service.GetInRange(startDate, endDate);
            return Ok(tasks);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            try
            {
                var task = _service.Details(id);

                if (task == null)
                    return Json(new { success = false });
                else
                    return Ok(task);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Operation error: details [{e}]");
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult Create([FromBody] Task task)
        {
            try
            {
                if (task == null)
                    return Json(new { success = false });

                var result = _service.Create(task);

                _logger.LogInformation($"Add task [{result}]");

                return Json(new { success = result });
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Operation error: add task [{e}]");
            }
            return Json(new { success = false});
        }

        [HttpPost]
        public IActionResult Edit(Guid id, [FromBody] Task task)
        {
            try
            {
                if (task == null)
                    return Json(new { success = false });

                task.Id = id;
                var result = _service.Update(task);
                _logger.LogInformation($"Update task [{result}]");

                return Json(new { success = result });
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Operation error: update task [{e}]");
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var result = _service.Delete(id);
                _logger.LogInformation($"Delete task [{result}]");

                return Json(new { success = result });
            } catch (Exception e)
            {
                _logger.LogInformation($"Operation error: remove task [{e}]");
            }
            return Json(new { success = false });
        }
    }
}
