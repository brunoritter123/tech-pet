using System.ComponentModel.DataAnnotations;

namespace TechPet.UseCase.Usuarios.Logar
{
    public class LogarUsuarioRequest
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberUser { get; set; }

        public LogarUsuarioRequest(string login, string password, bool rememberUser)
        {
            Login = login;
            Password = password;
            RememberUser = rememberUser;
        }

    }
}
