namespace TaskApis.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskApis.Entities.Enums.TaskStatus Status { get; set; } = TaskApis.Entities.Enums.TaskStatus.New;
        public Guid AssigneeId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }
    }
}
