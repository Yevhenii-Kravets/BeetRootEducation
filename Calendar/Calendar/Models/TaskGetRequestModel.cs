namespace Calendar.Models
{
    public class TaskGetRequestModel
    {
        public string? RequestId { get; set; }
        public IEnumerable<TaskModel> Tasks { get; set; } = new List<TaskModel>();
 
        public class TaskModel
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string? Description { get; set; }
            public DateTime Date { get; set; }
            public string Color { get; set; }
        }
    }
}