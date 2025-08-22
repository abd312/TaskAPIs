namespace TaskApis.DTOs
{
    public record CreateTaskDto(string Title, string? Description, Guid AssigneeId, DateTime? DueDate);
    public record UpdateTaskDto(string? Title, string? Description, TaskApis.Entities.Enums.TaskStatus? Status, Guid? AssigneeId, DateTime? DueDate);
    public record UpdateTaskStatusDto(TaskApis.Entities.Enums.TaskStatus Status);
    public record TaskDto(Guid Id, string Title, string? Description, TaskApis.Entities.Enums.TaskStatus Status, Guid AssigneeId, DateTime CreatedAt, DateTime? DueDate);

}
