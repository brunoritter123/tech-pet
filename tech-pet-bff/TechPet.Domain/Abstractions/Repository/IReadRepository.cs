using TechPet.Domain.Abstractions.Entities;
using TechPet.Domain.Abstractions.Paginacao;

namespace TechPet.Domain.Abstractions.Repository
{
    public interface IReadRepository<TEntity, in TId>
        where TEntity : Entity
        where TId : struct
    {
        Task<bool> ExisteAsync(TId id);

        Task<TEntity?> BuscarPorIdAsync(TId id);

        Task<TEntity?> BuscarPorIdAsTrackingAsync(TId id);

        Task<Page<TEntity>> ListarAsync(int page = 1, int pageSize = 10000, CancellationToken cancellationToken = default(CancellationToken));
    }
}
