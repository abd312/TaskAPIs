using Microsoft.AspNetCore.Mvc;
using TaskApis.Auth;
using TaskApis.DTOs.Services;
using TaskApis.DTOs;
using TaskApis.Entities.Enums;

namespace TaskApis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;
        private readonly CurrentUserAccessor _userAccessor;

        public TasksController(ITaskService service, CurrentUserAccessor accessor)
        {
            _service = service;
            _userAccessor = accessor;
        }

        private bool IsAdmin() => _userAccessor.GetCurrentUser()?.Role == UserRole.Admin;

        [HttpGet]
        public IActionResult GetAll() => IsAdmin() ? Ok(_service.GetAll()) : Forbid();

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var currentUser = _userAccessor.GetCurrentUser()!;
            var task = _service.Get(id, currentUser);
            return task is null ? Forbid() : Ok(task);
        }

        [HttpPost]
        public IActionResult Create(CreateTaskDto dto) => IsAdmin() ? Ok(_service.Create(dto)) : Forbid();

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateTaskDto dto)
        {
            var currentUser = _userAccessor.GetCurrentUser()!;
            try { _service.Update(id, dto, currentUser); return NoContent(); }
            catch (UnauthorizedAccessException) { return Forbid(); }
        }

        [HttpPatch("{id}/status")]
        public IActionResult UpdateStatus(Guid id, UpdateTaskStatusDto dto)
        {
            var currentUser = _userAccessor.GetCurrentUser()!;
            try { _service.UpdateStatus(id, dto, currentUser); return NoContent(); }
            catch (UnauthorizedAccessException) { return Forbid(); }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var currentUser = _userAccessor.GetCurrentUser()!;
            try { _service.Delete(id); return NoContent(); }
            catch (UnauthorizedAccessException) { return Forbid(); }

        } /*=> IsAdmin() ? Ok(_service.Delete(id)) : Forbid();*/
    }
}
