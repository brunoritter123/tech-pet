using Microsoft.AspNetCore.Identity;

namespace TechPet.Identity.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}