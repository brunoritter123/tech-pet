using TechPet.Domain.Abstractions;

namespace TechPet.Domain.Entities.Usuarios
{
    public class Usuario : Entity<Guid>
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public Usuario(string login, string nome, string email)
        {
            Login = login;
            Nome = nome;
            Email = email;
            Validar();
        }

        public Usuario()
        {
            Login = null!;
            Nome = null!;
            Email = null!;
        }

        public UsuarioResult ToUsuarioResult()
            => new UsuarioResult(Login, Nome, Email);

        public override bool Validar()
            => OnValidate(this, new UsuarioValidador());
    }
}
