using TaskApis.DAL;
using TaskApis.Entities.Enums;
using TaskApis.Entities;

namespace TaskApis.DTOs.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        public TaskService(AppDbContext context) => _context = context;

        public IEnumerable<TaskDto> GetAll() =>
            _context.Tasks.Select(t => new TaskDto(t.Id, t.Title, t.Description, t.Status, t.AssigneeId, t.CreatedAt, t.DueDate));

        public TaskDto? Get(Guid id, User currentUser)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return null;
            if (currentUser.Role != UserRole.Admin && task.AssigneeId != currentUser.Id) return null;
            return new TaskDto(task.Id, task.Title, task.Description, task.Status, task.AssigneeId, task.CreatedAt, task.DueDate);
        }

        public TaskDto Create(CreateTaskDto dto)
        {
            var task = new TaskItem { Title = dto.Title, Description = dto.Description, AssigneeId = dto.AssigneeId, DueDate = dto.DueDate };
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return new TaskDto(task.Id, task.Title, task.Description, task.Status, task.AssigneeId, task.CreatedAt, task.DueDate);
        }

        public void Update(Guid id, UpdateTaskDto dto, User currentUser)
        {
            var task = _context.Tasks.Find(id) ?? throw new KeyNotFoundException();
            if (currentUser.Role != UserRole.Admin && task.AssigneeId != currentUser.Id)
                throw new UnauthorizedAccessException();

            if (currentUser.Role == UserRole.Admin)
            {
                if (dto.Title != null) task.Title = dto.Title;
                if (dto.Description != null) task.Description = dto.Description;
                if (dto.Status != null) task.Status = dto.Status.Value;
                if (dto.AssigneeId != null) task.AssigneeId = dto.AssigneeId.Value;
                if (dto.DueDate != null) task.DueDate = dto.DueDate;
            }
            else
            {
                if (dto.Status != null) task.Status = dto.Status.Value;
                else throw new UnauthorizedAccessException();
            }
            _context.SaveChanges();
        }

        public void UpdateStatus(Guid id, UpdateTaskStatusDto dto, User currentUser)
        {
            var task = _context.Tasks.Find(id) ?? throw new KeyNotFoundException();
            if (task.AssigneeId != currentUser.Id) throw new UnauthorizedAccessException();
            task.Status = dto.Status;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var task = _context.Tasks.Find(id) ?? throw new KeyNotFoundException();
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}
