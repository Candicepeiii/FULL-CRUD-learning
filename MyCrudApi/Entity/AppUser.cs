using Microsoft.AspNetCore.Identity;

namespace MyCrudApi.Entity
{
    public class AppUser : IdentityUser
    {
        public required string FullName { get; set; }
    }
}
