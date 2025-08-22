using TaskApis.DAL;
using TaskApis.Entities;

namespace TaskApis.DTOs.Services
{

    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context) => _context = context;

        public IEnumerable<UserDto> GetAll() => _context.Users.Select(u => new UserDto(u.Id, u.Username, u.DisplayName, u.Role));
        public UserDto? Get(Guid id) => _context.Users.Where(u => u.Id == id).Select(u => new UserDto(u.Id, u.Username, u.DisplayName, u.Role)).FirstOrDefault();
        public UserDto Create(CreateUserDto dto)
        {
            var user = new User { Username = dto.Username, DisplayName = dto.DisplayName, Role = dto.Role };
            _context.Users.Add(user);
            _context.SaveChanges();
            return new UserDto(user.Id, user.Username, user.DisplayName, user.Role);
        }
        public void Update(Guid id, UpdateUserDto dto)
        {
            var user = _context.Users.Find(id) ?? throw new KeyNotFoundException();
            if (dto.DisplayName != null) user.DisplayName = dto.DisplayName;
            if (dto.Role != null) user.Role = dto.Role.Value;
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var user = _context.Users.Find(id) ?? throw new KeyNotFoundException();
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
