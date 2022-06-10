using TechPet.Domain.Abstractions.Entities;

namespace TechPet.Domain.Entities.Usuarios
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
            Validar();
        }

        public override bool Validar()
            => OnValidate(this, new UsuarioValidador());

        public override NomeAmigavelDaEntitidade GetNomeDaEntitidadeAmigavel()
            => new NomeAmigavelDaEntitidade("o", "os", "usuário", "usuários");
    }
}
