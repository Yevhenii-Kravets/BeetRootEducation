using BuisnessLogic;
using BuisnessLogic.Interfaces;
using Calendar.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using Task = Models.Task;

namespace Calendar.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private readonly IServiceItem<Task> _service;
        private readonly IValidator<TaskRequestModel> _validator;

        public TaskController(ILogger<TaskController> logger, CalendarDbContext calendar, IServiceItem<Task> service, IValidator<TaskRequestModel> validator)
        {
            _logger = logger;
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        public IActionResult Range(DateTime startDate, DateTime endDate) 
        {
            if(endDate > startDate)
                return Json(new { success = false, error = "Start date is less than end date" });

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
        public IActionResult Create([FromBody] TaskRequestModel task)
        {
            var validation = _validator.Validate(task);
            if (!validation.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();

                return Json(new { success = false, validation.Errors });
            }

            try
            {
                if (task == null)
                    return Json(new { success = false });

                var result = _service.Create(new Task() 
                { 
                    Title = task.Title,
                    Description = task.Description,
                    Date = task.Date,
                    Color = task.Color
                });

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
        public IActionResult Edit(Guid id, [FromBody] TaskRequestModel task)
        {
            var validation = _validator.Validate(task);
            if (!validation.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();

                return Json(new { success = false, validation.Errors });
            }
            try
            {
                if (task == null)
                    return Json(new { success = false });

                var result = _service.Update(new Task() {
                    Id = id,
                    Title = task.Title,
                    Description = task.Description,
                    Date = task.Date,
                    Color = task.Color
                });
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
