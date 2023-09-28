using BuisnessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace BuisnessLogic.Services
{
    public class EventService : IServiceItem<Event>
    {
        private readonly CalendarDbContext _calendar;

        public EventService(CalendarDbContext calendar)
        {
            _calendar = calendar;
        }

        public IEnumerable<Event> GetAll()
        {
            return _calendar.Events
                .Include(e => e.Repeat)
                .Include(e => e.Theme)
                .ToList();
        }

        public IEnumerable<Event> GetInRange(DateTime start, DateTime end)
        {
            return _calendar.Events
                .Include(e => e.Repeat)
                .Include(e => e.Theme)
                .Where(@event => @event.StartDate <= end && @event.EndDate >= start)
                .ToList();
        }

        public Guid Create(Event e)
        {
            if (_calendar.Events.FirstOrDefault(ev => ev.Id == e.Id) != null)
                throw new InvalidOperationException($"Creation failed. Item with ID {e.Id} is found.");

            _calendar.Events.Add(e);

            var result = _calendar.SaveChanges();

            return e.Id;
        }
        public Guid Update(Event e)
        {
            var @event = _calendar.Events
                .Include(e => e.Theme)
                .Include(e => e.Repeat)
                .FirstOrDefault(ev => ev.Id == e.Id);

            if (@event == null)
                throw new InvalidOperationException($"Update failed. Item with ID {e.Id} not found.");

            //
            @event.Title = e.Title;
            @event.Description = e.Description;
            @event.StartDate = e.StartDate;
            @event.EndDate = e.EndDate;

            //
            @event.Theme.Name = e.Theme.Name;
            @event.Theme.BackgroundColor = e.Theme.BackgroundColor;
            @event.Theme.TextColor = e.Theme.TextColor;

            //
            @event.Repeat.RepeatsCount = e.Repeat.RepeatsCount;

            @event.Repeat.Monday = e.Repeat.Monday;
            @event.Repeat.Tuesday = e.Repeat.Tuesday;
            @event.Repeat.Wednesday = e.Repeat.Wednesday;
            @event.Repeat.Thursday = e.Repeat.Thursday;
            @event.Repeat.Friday = e.Repeat.Friday;
            @event.Repeat.Saturday = e.Repeat.Saturday;
            @event.Repeat.Sunday = e.Repeat.Sunday;

            @event.Repeat.Day = e.Repeat.Day;
            @event.Repeat.Week = e.Repeat.Week;
            @event.Repeat.Month = e.Repeat.Month;
            @event.Repeat.Year = e.Repeat.Year;

            //
            var result = _calendar.SaveChanges();

            return e.Id;
        }
        public Guid Delete(Guid id)
        {
            var @event = _calendar.Events.FirstOrDefault(e => e.Id == id);

            if (@event == null)
                throw new InvalidOperationException($"Delete failed. Item with ID {id} not found.");

            _calendar.Events.Remove(@event);

            var result = _calendar.SaveChanges();

            return id;
        }

        public Event Details(Guid id)
        {
            var @event = _calendar.Events.FirstOrDefault(e => e.Id == id);

            return @event;
        }
    }
}
