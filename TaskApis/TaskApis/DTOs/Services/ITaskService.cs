using TaskApis.Entities;

namespace TaskApis.DTOs.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAll();
        TaskDto? Get(Guid id, User currentUser);
        TaskDto Create(CreateTaskDto dto);
        void Update(Guid id, UpdateTaskDto dto, User currentUser);
        void UpdateStatus(Guid id, UpdateTaskStatusDto dto, User currentUser);
        void Delete(Guid id);
    }
}
