using Pressur.Domain.Abstractions.Entities;
using Pressur.Domain.Abstractions.FluentResults;
using Pressur.Domain.Abstractions.Paginacao;

namespace Pressur.Domain.Abstractions.Repository
{
    public interface IReadRepository<TEntity, in TId>
        where TEntity : Entity
        where TId : struct
    {
        Task<Result<bool>> ExisteAsync(TId id);

        Task<Result<TEntity>> BuscarPorIdAsync(TId id);

        Task<Result<TEntity>> BuscarPorIdAsTrackingAsync(TId id);

        Task<Result<Page<TEntity>>> ListarAsync(int page = 1, int pageSize = 10000, CancellationToken cancellationToken = default(CancellationToken));
    }
}
