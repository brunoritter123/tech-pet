using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechPet.Identity.Entities;
using TechPet.Identity.Interfaces;

namespace TechPet.Identity.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _accessor;
        public JwtService(IConfiguration config, IHttpContextAccessor accessor)
        {
            _config = config;
            _accessor = accessor;
        }

        public string GenerateJWToken(User user, IEnumerable<string>? rolesAdicionais)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.UserData, user.CodigoEmpresa )
            };

            foreach (var role in user.UserRoles.Where(x => x != null))
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }

            foreach (var role in rolesAdicionais ?? Enumerable.Empty<string>())
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("TokenConfig:JwtSecretKey").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            int expiresToken = ((int)(DateTime.UtcNow.Date.AddDays(1) - DateTime.UtcNow).TotalMinutes);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _config.GetSection("TokenConfig:Issuer").Value,
                Audience = _config.GetSection("TokenConfig:Audience").Value,
                Expires = DateTime.UtcNow.AddMinutes(expiresToken),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string? GetUserData()
        {
            
            return _accessor?.HttpContext?.User.FindFirst(ClaimTypes.UserData)?.Value;
        }
    }
}
