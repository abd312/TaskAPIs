namespace TaskApis.DTOs.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        UserDto? Get(Guid id);
        UserDto Create(CreateUserDto dto);
        void Update(Guid id, UpdateUserDto dto);
        void Delete(Guid id);
    }
}
