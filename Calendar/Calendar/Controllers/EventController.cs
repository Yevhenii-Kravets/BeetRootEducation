using BuisnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

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
            var @event = _service.GetAll().FirstOrDefault(e => e.Id == id);

            if (@event == null)
                return Json(new { success = false });
            else
                return Ok(@event);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Event @event)
        {
            if (@event == null)
                return Json(new { success = false });

            var result = _service.Create(@event);
            _logger.LogInformation($"Add event {result}");

            return Json(new { success = result });
        }

        [HttpPost]
        public IActionResult Edit(Guid id, [FromBody] Event @event)
        {
            if (@event == null)
                return Json(new { success = false });

            @event.Id = id;
            var result = _service.Update(@event);
            _logger.LogInformation($"Update event {result}");

            return Json(new { success = result });
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var result = _service.Delete(id);
            _logger.LogInformation($"Delete event {result}");

            return Json(new { success = result });
        }



    }
}
