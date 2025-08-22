using Microsoft.AspNetCore.Mvc;
using TaskApis.Auth;
using TaskApis.DTOs.Services;
using TaskApis.DTOs;
using TaskApis.Entities.Enums;

namespace TaskApis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly CurrentUserAccessor _userAccessor;

        public UsersController(IUserService service, CurrentUserAccessor accessor)
        {
            _service = service;
            _userAccessor = accessor;
        }

        private bool IsAdmin() => _userAccessor.GetCurrentUser()?.Role == UserRole.Admin;

        [HttpGet]
        public IActionResult GetAll() => IsAdmin() ? Ok(_service.GetAll()) : Forbid();

        [HttpGet("{id}")]
        public IActionResult Get(Guid id) => IsAdmin() ? Ok(_service.Get(id)) : Forbid();

        [HttpPost]
        public IActionResult Create(CreateUserDto dto) => IsAdmin() ? Ok(_service.Create(dto)) : Forbid();

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateUserDto dto) { if (!IsAdmin()) return Forbid(); _service.Update(id, dto); return NoContent(); }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) { if (!IsAdmin()) return Forbid(); _service.Delete(id); return NoContent(); }
    }
}
