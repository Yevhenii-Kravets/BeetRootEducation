using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public EventTheme Theme { get; set; }
        public EventRepeat Repeat { get; set; }

    }
}