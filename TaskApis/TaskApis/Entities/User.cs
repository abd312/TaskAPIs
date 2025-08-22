using TaskApis.Entities.Enums;

namespace TaskApis.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = string.Empty;
        public string? DisplayName { get; set; }
        public UserRole Role { get; set; }
    }
}
