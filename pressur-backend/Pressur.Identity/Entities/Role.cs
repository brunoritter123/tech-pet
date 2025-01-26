using Microsoft.AspNetCore.Identity;

namespace Pressur.Identity.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}