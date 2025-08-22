using TaskApis.Entities;

namespace TaskApis.Auth
{
    public class CurrentUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserAccessor(IHttpContextAccessor accessor) => _httpContextAccessor = accessor;

        public User? GetCurrentUser()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null) return null;

            if (!context.Items.TryGetValue("CurrentUser", out var user)) return null;
            return user as User;
        }
    }
}
