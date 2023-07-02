namespace Scheme
{
    public class Meeting
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Room Room { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }
    }
}