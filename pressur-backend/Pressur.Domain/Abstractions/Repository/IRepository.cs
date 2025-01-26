using Pressur.Domain.Abstractions.Entities;
using Pressur.Domain.Abstractions.FluentResults;

namespace Pressur.Domain.Abstractions.Repository
{
    public interface IRepository<TEntity, in TId> : IReadRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        Task<Result<TEntity>> AddAsync(TEntity entity, bool saveChanges = true);

        Task<Result> DeleteAsync(TId id, bool saveChanges = true);

        Task<Result> UpdateAsync(TEntity entity, bool saveChanges = true);

    }
}
