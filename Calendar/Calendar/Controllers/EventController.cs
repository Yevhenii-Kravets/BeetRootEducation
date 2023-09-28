using BuisnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Calendar.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;
        private readonly IServiceItem<Event> _service;

        public EventController(ILogger<EventController> logger, IServiceItem<Event> service)
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
            var events = _service.GetInRange(startDate, endDate);

            return Ok(events);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            try
            {
                var @event = _service.Details(id);

                if (@event == null)
                    return Json(new { success = false });
                else
                    return Ok(@event);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Operation error: details [{e}]");
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult Create([FromBody] Event @event)
        {
            try
            {
                if (@event == null)
                    return Json(new { success = false });

                var result = _service.Create(@event);
                _logger.LogInformation($"Add event [{result}]");

                return Json(new { success = result });
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Operation error: add event [{e}]");
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult Edit(Guid id, [FromBody] Event @event)
        {
            try
            {
                if (@event == null)
                    return Json(new { success = false });

                @event.Id = id;
                var result = _service.Update(@event);
                _logger.LogInformation($"Update event [{result}]");

                return Json(new { success = result });
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Operation error: update event [{e}]");
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var result = _service.Delete(id);
                _logger.LogInformation($"Delete event [{result}]");

                return Json(new { success = result });
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Operation error: remove event [{e}]");
            }
            return Json(new { success = false });
        }



    }
}
