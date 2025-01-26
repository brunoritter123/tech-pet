using Microsoft.AspNetCore.Identity;

namespace Pressur.Identity.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Nome { get; set; }
        public string CodigoEmpresa { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }

        public User()
        {
            UserRoles = new List<UserRole>();
        }
    }
}
