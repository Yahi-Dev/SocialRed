using SocialRed.Core.Application.Helpers;
using SocialRed.Core.Application.DTOs.Account;

namespace SocialRed.Middelwares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor httpContext;


        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor;
        }

        public bool HasUser()
        {
            AuthenticationResponse vm = httpContext.HttpContext.Session.Get<AuthenticationResponse>("user");
            if (vm == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
