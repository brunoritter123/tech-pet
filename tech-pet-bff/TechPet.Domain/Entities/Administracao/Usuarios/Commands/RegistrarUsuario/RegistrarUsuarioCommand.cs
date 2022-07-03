using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TechPet.Domain.Entities.Usuarios.Commands.RegistrarUsuario
{
    public class RegistrarUsuarioCommand : IRequest<UsuarioResult?>
    {

        [Required]
        public string Nome { get; set; } = String.Empty;

        [Required]
        public string Login { get; set; } = String.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = String.Empty;

        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string Senha { get; set; } = String.Empty;

        protected RegistrarUsuarioCommand()
        {

        }

        public RegistrarUsuarioCommand(string nome, string login, string email, string senha)
        {
            Nome = nome;
            Login = login;
            Email = email;
            Senha = senha;
        }
    }
}