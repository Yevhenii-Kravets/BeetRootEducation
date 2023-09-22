using Models;

namespace BuisnessLogic.Services
{
    public class EventServices
    {
        private readonly CalendarDbContext _calendar;

        public EventServices(CalendarDbContext calendar)
        {
            _calendar = calendar;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _calendar.Events.ToList();
        }

        public Guid CreateEvent(Event e, Theme t, Repeat r)
        {
            _calendar.Events.Add(e);
            _calendar.Themes.Add(t);
            _calendar.Repeats.Add(r);

            var result = _calendar.SaveChanges();

            return e.Id;
        }
        public bool UpdateEvent(Event e, Theme t, Repeat r)
        {
            //
            Event? eventToUpdate = _calendar.Events.FirstOrDefault(ev => ev.Id == e.Id);
            eventToUpdate.Title = e.Title;
            eventToUpdate.Description = e.Description;
            eventToUpdate.StartDate = e.StartDate;
            eventToUpdate.EndDate = e.EndDate;

            //
            Theme? themeToUpdate = _calendar.Themes.FirstOrDefault(th => th.Id == e.Theme);
            themeToUpdate.Name = t.Name;
            themeToUpdate.BackgroundColor = t.BackgroundColor;
            themeToUpdate.TextColor = t.TextColor;

            //
            Repeat? repeatToUpdate = _calendar.Repeats.FirstOrDefault(re => re.Id == e.Repeat);
            repeatToUpdate.RepeatsCount = r.RepeatsCount;

            repeatToUpdate.Monday = r.Monday;
            repeatToUpdate.Tuesday = r.Tuesday;
            repeatToUpdate.Wednesday = r.Wednesday;
            repeatToUpdate.Thursday = r.Thursday;
            repeatToUpdate.Friday = r.Friday;
            repeatToUpdate.Saturday = r.Saturday;
            repeatToUpdate.Sunday = r.Sunday;

            repeatToUpdate.Day = r.Day;
            repeatToUpdate.Week = r.Week;
            repeatToUpdate.Month = r.Month;
            repeatToUpdate.Year = r.Year;

            //
            var result = _calendar.SaveChanges();
            return true;
        }
        public bool DeleteEvent(Guid id)
        {
            var eventToDelete = _calendar.Events.FirstOrDefault(e => e.Id == id);
            Theme? themeToDelete = _calendar.Themes.FirstOrDefault(th => th.Id == eventToDelete.Theme);
            Repeat? repeatToDelete = _calendar.Repeats.FirstOrDefault(re => re.Id == eventToDelete.Repeat);

            if (eventToDelete != null && themeToDelete != null && repeatToDelete != null)
            {
                _calendar.Themes.Remove(themeToDelete);
                _calendar.Repeats.Remove(repeatToDelete);
                _calendar.Events.Remove(eventToDelete);

                var result = _calendar.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public Theme GetTheme(Guid id)
        {
            return _calendar.Themes.FirstOrDefault(t => t.Id == id);
        }
        public Repeat GetRepeat(Guid id)
        {
            return _calendar.Repeats.FirstOrDefault(r => r.Id == id);
        }
    }
}
