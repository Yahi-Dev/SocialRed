using Microsoft.AspNetCore.Identity;

namespace SocialRed.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string? ImageProfile { get; set; }
    }
}
