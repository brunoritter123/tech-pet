using System.ComponentModel.DataAnnotations;

namespace TechPet.UseCase.Requests
{
    public class UsuarioLoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public UsuarioLoginRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

    }
}
