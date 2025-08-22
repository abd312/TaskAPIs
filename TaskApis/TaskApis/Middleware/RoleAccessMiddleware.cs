using TaskApis.Entities.Enums;
using TaskApis.Entities;

namespace TaskApis.Middleware
{
    public class RoleAccessMiddleware
    {
        private readonly RequestDelegate _next;
        public RoleAccessMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var userIdHeader = context.Request.Headers["X-User-Id"].FirstOrDefault();
            var roleHeader = context.Request.Headers["X-User-Role"].FirstOrDefault();

            if (Guid.TryParse(userIdHeader, out var userId) && Enum.TryParse<UserRole>(roleHeader, out var role))
            {
                var user = new User { Id = userId, Role = role, Username = roleHeader.ToLower() };
                context.Items["CurrentUser"] = user;
            }

            await _next(context);
        }
    }
}
