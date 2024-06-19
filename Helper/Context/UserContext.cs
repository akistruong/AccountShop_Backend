using System.Security.Claims;

namespace AccountShop.Helper.Context
{
    public class UserContext
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetNameIdentifier()
        {
            var context = this._httpContextAccessor.HttpContext;
            var ID = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return ID??"";
        }
    }
}
