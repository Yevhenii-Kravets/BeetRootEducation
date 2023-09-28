using BuisnessLogic;
using BuisnessLogic.Interfaces;
using Calendar.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace Calendar.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;
        private readonly IServiceItem<Event> _service;
        private readonly IValidator<EventRequestModel> _validator;

        public EventController(ILogger<EventController> logger, CalendarDbContext calendar, IServiceItem<Event> service, IValidator<EventRequestModel> validator)
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
            if (endDate > startDate)
                return Json(new { success = false, error = "Start date is less than end date" });

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
        public IActionResult Create([FromBody] EventRequestModel @event)
        {
            var validation = _validator.Validate(@event);
            if (!validation.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();

                return Json(new { success = false, validation.Errors });
            }
            try
            {
                if (@event == null)
                    return Json(new { success = false });

                var theme = new EventTheme()
                {
                    Name = @event.Theme.Name,
                    BackgroundColor = @event.Theme.BackgroundColor,
                    TextColor = @event.Theme.TextColor
                };

                var repeat = new EventRepeat()
                {
                    RepeatsCount = @event.Repeat.RepeatsCount,

                    Monday = @event.Repeat.Monday,
                    Tuesday = @event.Repeat.Tuesday,
                    Wednesday = @event.Repeat.Tuesday,
                    Thursday = @event.Repeat.Thursday,
                    Friday = @event.Repeat.Friday,
                    Saturday = @event.Repeat.Saturday,
                    Sunday = @event.Repeat.Sunday,

                    Day = @event.Repeat.Day,
                    Week = @event.Repeat.Week,
                    Month = @event.Repeat.Month,
                    Year = @event.Repeat.Year,
                };

                var result = _service.Create(new Event()
                {
                    Title = @event.Title,
                    Description = @event.Description,
                    StartDate = @event.StartDate,
                    EndDate = @event.EndDate,
                    Theme = theme,
                    Repeat = repeat
                });
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
        public IActionResult Edit(Guid id, [FromBody] EventRequestModel @event)
        {
            var validation = _validator.Validate(@event);
            if (!validation.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();

                return Json(new { success = false, validation.Errors });
            }
            try
            {
                if (@event == null)
                    return Json(new { success = false });

                var theme = new EventTheme()
                {
                    Name = @event.Theme.Name,
                    BackgroundColor = @event.Theme.BackgroundColor,
                    TextColor = @event.Theme.TextColor
                };

                var repeat = new EventRepeat()
                {
                    RepeatsCount = @event.Repeat.RepeatsCount,

                    Monday = @event.Repeat.Monday,
                    Tuesday = @event.Repeat.Tuesday,
                    Wednesday = @event.Repeat.Tuesday,
                    Thursday = @event.Repeat.Thursday,
                    Friday = @event.Repeat.Friday,
                    Saturday = @event.Repeat.Saturday,
                    Sunday = @event.Repeat.Sunday,

                    Day = @event.Repeat.Day,
                    Week = @event.Repeat.Week,
                    Month = @event.Repeat.Month,
                    Year = @event.Repeat.Year,
                };

                var result = _service.Update(new Event()
                {
                    Id = id,
                    Title = @event.Title,
                    Description = @event.Description,
                    StartDate = @event.StartDate,
                    EndDate = @event.EndDate,
                    Theme = theme,
                    Repeat = repeat
                });
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
