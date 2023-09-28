namespace Models
{
    public class EventTheme
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string BackgroundColor { get; set; } = "#007bff";
        public string TextColor { get; set; } = "#ffffff";
        public bool IsStatic { get; set; }
    }
}
