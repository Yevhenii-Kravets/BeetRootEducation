namespace Calendar.Models
{
    public class EventRequestModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EventTheme Theme { get; set; }
        public EventRepeat Repeat { get; set; }

        public class EventTheme
        {
            public string Name { get; set; }
            public string BackgroundColor { get; set; }
            public string TextColor { get; set; }
            public bool IsStatic { get; set; }
        }

        public class EventRepeat
        {
            public int RepeatsCount { get; set; }

            public bool Monday { get; set; }
            public bool Tuesday { get; set; }
            public bool Wednesday { get; set; }
            public bool Thursday { get; set; }
            public bool Friday { get; set; }
            public bool Saturday { get; set; }
            public bool Sunday { get; set; }

            public bool Day { get; set; }
            public bool Week { get; set; }
            public bool Month { get; set; }
            public bool Year { get; set; }
        }
    }
}
