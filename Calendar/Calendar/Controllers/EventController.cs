using BuisnessLogic;
using BuisnessLogic.Services;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Calendar.Models.EventPostRequestModel.EventModel;
using Theme = Models.Theme;

namespace Calendar.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;
        private readonly EventServices _services;

        public EventController(ILogger<EventController> logger, CalendarDbContext calendar)
        {
            _logger = logger;
            _services = new EventServices(calendar);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new EventGetRequestModel();

            var events = _services.GetAllEvents();

            var themes = events.Select(e => _services.GetTheme(e.Theme)).ToList();
            var repeats = events.Select(e => _services.GetRepeat(e.Repeat)).ToList();

            model.Events = events.Select((e, index) => new EventGetRequestModel.EventModel
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Theme = new EventGetRequestModel.EventModel.EventThemeModel
                {
                    Name = themes[index].Name,
                    BackgroundColor = themes[index].BackgroundColor,
                    TextColor = themes[index].TextColor
                },
                Repeat = new EventGetRequestModel.EventModel.EventRepeatModel
                {
                    RepeatsCount = repeats[index].RepeatsCount,
                    Monday = repeats[index].Monday,
                    Tuesday = repeats[index].Tuesday,
                    Wednesday = repeats[index].Wednesday,
                    Thursday = repeats[index].Thursday,
                    Friday = repeats[index].Friday,
                    Saturday = repeats[index].Saturday,
                    Sunday = repeats[index].Sunday,
                    Day = repeats[index].Day,
                    Week = repeats[index].Week,
                    Month = repeats[index].Month,
                    Year = repeats[index].Year
                }
            });

            return Ok(model.Events);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {

            var @event = _services.GetAllEvents().FirstOrDefault(e => e.Id == id);

            //if (@event != null)
            //{
                var theme = _services.GetTheme(@event.Theme);
                var repeat = _services.GetRepeat(@event.Repeat);


            var result = new EventGetRequestModel.EventModel
            {
                Id = @event.Id,
                Title = @event.Title,
                Description = @event.Description,
                StartDate = @event.StartDate,
                EndDate = @event.EndDate,
                Theme = new EventGetRequestModel.EventModel.EventThemeModel
                {
                    Name = theme.Name,
                    BackgroundColor = theme.BackgroundColor,
                    TextColor = theme.TextColor
                },
                Repeat = new EventGetRequestModel.EventModel.EventRepeatModel
                {
                    RepeatsCount = repeat.RepeatsCount,
                    Monday = repeat.Monday,
                    Tuesday = repeat.Tuesday,
                    Wednesday = repeat.Wednesday,
                    Thursday = repeat.Thursday,
                    Friday = repeat.Friday,
                    Saturday = repeat.Saturday,
                    Sunday = repeat.Sunday,
                    Day = repeat.Day,
                    Week = repeat.Week,
                    Month = repeat.Month,
                    Year = repeat.Year
                }
                //};
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EventPostRequestModel.EventModel e)
        {
            if (e != null)
            {
                var theme = new Theme
                {
                    Id = Guid.NewGuid(),
                    Name = e.Theme.Name,
                    BackgroundColor = e.Theme.BackgroundColor,
                    TextColor = e.Theme.TextColor
                };

                var repeat = new Repeat
                {
                    Id = Guid.NewGuid(),
                    RepeatsCount = e.Repeat.RepeatsCount,

                    Monday = e.Repeat.Monday,
                    Tuesday = e.Repeat.Tuesday,
                    Wednesday = e.Repeat.Wednesday,
                    Thursday = e.Repeat.Thursday,
                    Friday = e.Repeat.Friday,
                    Saturday = e.Repeat.Saturday,
                    Sunday = e.Repeat.Sunday,

                    Day = e.Repeat.Day,
                    Week = e.Repeat.Week,
                    Month = e.Repeat.Month,
                    Year = e.Repeat.Year
                };

                var @event = new Event
                {
                    Id = Guid.NewGuid(),
                    Title = e.Title,
                    Description = e.Description,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Theme = theme.Id,
                    Repeat = repeat.Id
                };

                _services.CreateEvent(@event, theme, repeat);

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public IActionResult Edit(Guid id, [FromBody] EventPostRequestModel.EventModel e)
        {
            if (e == null)
                return Json(new { success = false });

            var eventToUpdate = _services.GetAllEvents().FirstOrDefault(ev => ev.Id == id);

            if (eventToUpdate == null)
                return Json(new { success = false });

            eventToUpdate.Title = e.Title;
            eventToUpdate.Description = e.Description;
            eventToUpdate.StartDate = e.StartDate;
            eventToUpdate.EndDate = e.EndDate;

            Theme themeToUpdate = _services.GetTheme(eventToUpdate.Theme);
            themeToUpdate.Name = e.Theme.Name;
            themeToUpdate.BackgroundColor = e.Theme.BackgroundColor;
            themeToUpdate.TextColor = e.Theme.TextColor;

            Repeat repeatToUpdate = _services.GetRepeat(eventToUpdate.Repeat);
            repeatToUpdate.RepeatsCount = e.Repeat.RepeatsCount;
            repeatToUpdate.Monday = e.Repeat.Monday;
            repeatToUpdate.Tuesday = e.Repeat.Tuesday;
            repeatToUpdate.Wednesday = e.Repeat.Wednesday;
            repeatToUpdate.Thursday = e.Repeat.Thursday;
            repeatToUpdate.Friday = e.Repeat.Friday;
            repeatToUpdate.Saturday = e.Repeat.Saturday;
            repeatToUpdate.Sunday = e.Repeat.Sunday;
            repeatToUpdate.Sunday = e.Repeat.Sunday;
            repeatToUpdate.Day = e.Repeat.Day;
            repeatToUpdate.Week = e.Repeat.Week;
            repeatToUpdate.Month = e.Repeat.Month;
            repeatToUpdate.Year = e.Repeat.Year;

            _services.UpdateEvent(eventToUpdate, themeToUpdate, repeatToUpdate);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var result = _services.DeleteEvent(id);

            if(result)
                return Json(new { success = true });
            else
                return Json(new { success = false });
        }



    }
}
