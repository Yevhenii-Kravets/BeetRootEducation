namespace Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string? Color { get; set; }
    }
}
