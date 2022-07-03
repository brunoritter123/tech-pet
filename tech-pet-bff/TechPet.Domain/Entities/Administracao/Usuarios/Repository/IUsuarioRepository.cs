using TechPet.Domain.Abstractions.Repository;

namespace TechPet.Domain.Entities.Usuarios.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario, Guid>
    {
        Task<Usuario?> BuscarPorLoginAsync(string login);
    }
}
