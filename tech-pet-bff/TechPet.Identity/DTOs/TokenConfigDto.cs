using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechPet.Identity.DTOs
{
    public class TokenConfigDto
    {
        public int Expiration { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string JwtSecretKey { get; set; } = string.Empty;
    }
}
