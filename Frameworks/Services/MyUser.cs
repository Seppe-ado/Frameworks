using Frameworks.Areas.Identity.Data;
using Frameworks.Data;

namespace Frameworks.Services
{
    public interface IMyUser
    {
        public FrameworksUser User();
    }
    public class MyUser : IMyUser
    {
        readonly FrameworksContext _context;
        readonly IHttpContextAccessor _httpContext;
        FrameworksUser user = null;

        public MyUser (FrameworksContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }


        public FrameworksUser User()
        {
            string name = _httpContext.HttpContext.User.Identity.Name;
            if (user == null || user.UserName != name)
            {
                user = _context.Users.First(p => p.UserName == (string.IsNullOrEmpty(name)? "Admin" : name));
            }
            return user;
        }


    }
}
