using Pressur.Domain.Entities.Administracao;

namespace Pressur.Domain.Abstractions.Repository;
public interface IUsuarioRepository : IRepository<Usuario, Guid>
{
    Task<Usuario?> BuscarPorLoginAsync(string login);
}
