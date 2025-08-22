using TaskApis.Entities.Enums;

namespace TaskApis.DTOs
{
    public record CreateUserDto(string Username, string? DisplayName, UserRole Role);
    public record UpdateUserDto(string? DisplayName, UserRole? Role);
    public record UserDto(Guid Id, string Username, string? DisplayName, UserRole Role);
}
