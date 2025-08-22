using TaskApis.Entities.Enums;
using TaskApis.Entities;
using TaskStatus = TaskApis.Entities.Enums.TaskStatus;

namespace TaskApis.DAL
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Users.Any()) return;

            var admin = new User { Id = Guid.NewGuid(), Username = "admin", Role = UserRole.Admin };
            var user = new User { Id = Guid.NewGuid(), Username = "user", Role = UserRole.User };

            context.Users.AddRange(admin, user);

            context.Tasks.AddRange(
                new TaskItem { Title = "Setup project", AssigneeId = admin.Id, Status = TaskStatus.InProgress },
                new TaskItem { Title = "Write docs", AssigneeId = user.Id, Status = TaskStatus.New },
                new TaskItem { Title = "Fix bug #123", AssigneeId = user.Id, Status = TaskStatus.New }
            );

            context.SaveChanges();
        }
    }
}
