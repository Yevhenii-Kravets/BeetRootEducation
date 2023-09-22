namespace Calendar.Models
{
    public class TaskPostRequestModel
    {
        public string? RequestId { get; set; }
        public TaskModel? Task { get; set; }

        public class TaskModel
        {
            public string Title { get; set; }
            public string? Description { get; set; }
            public DateTime Date { get; set; }
            public string Color { get; set; }
        }
    }
}