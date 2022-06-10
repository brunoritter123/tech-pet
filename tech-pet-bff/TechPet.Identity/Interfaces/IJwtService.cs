using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Identity.Entities;

namespace TechPet.Identity.Interfaces
{
    public interface IJwtService
    {
        string GenerateJWToken(User user, IEnumerable<string>? rolesAdicionais);
    }
}
