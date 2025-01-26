using Pressur.Domain.Abstractions.Entities;

namespace Pressur.Domain.Entities.Administracao
{
    public class Usuario : Entity<Guid>
    {
        public string Login { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }

        public Usuario(string login, string nome, string email)
        {
            Login = login;
            Nome = nome;
            Email = email;
        }
    }
}
