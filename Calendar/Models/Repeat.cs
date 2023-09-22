namespace Models
{
    public class Repeat
    {
        public Guid Id { get; set; }
        public int RepeatsCount { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set;}
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public bool Day { get; set; }
        public bool Week { get; set; }
        public bool Month { get; set; }
        public bool Year { get; set; }
    }
}
