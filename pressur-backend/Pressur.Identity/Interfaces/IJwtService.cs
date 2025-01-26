using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Pressur.Identity.Entities;

namespace Pressur.Identity.Interfaces
{
    public interface IJwtService
    {
        string GenerateJWToken(User user, IEnumerable<string>? rolesAdicionais);
        string? GetCodigoEmpresaUserLogado();
        bool IsAdmin();
    }
}
