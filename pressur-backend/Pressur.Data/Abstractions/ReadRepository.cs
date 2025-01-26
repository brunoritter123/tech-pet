using Microsoft.EntityFrameworkCore;
using Pressur.Data.Context;
using Pressur.Domain.Abstractions.Entities;
using Pressur.Domain.Abstractions.FluentResults;
using Pressur.Domain.Abstractions.Paginacao;
using Pressur.Domain.Abstractions.Repository;

namespace Pressur.Data.Abstractions
{
    public abstract class ReadRepository<TEntity, TId> : IReadRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        protected readonly DbSet<TEntity> DbSet;

        protected ReadRepository(PressurContext dbContext)
        {
            DbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<Result<TEntity>> BuscarPorIdAsync(TId id)
        {
            return await DbSet.AsNoTracking().SingleOrDefaultAsync(x => id.Equals(x.Id));
        }

        public virtual async Task<Result<TEntity>> BuscarPorIdAsTrackingAsync(TId id)
        {
            return await DbSet.FindAsync(new object[] { id });
        }

        public virtual async Task<Result<bool>> ExisteAsync(TId id)
        {
            return  await DbSet.AnyAsync(x => id.Equals(x.Id));
        }

        public virtual async Task<Result<Page<TEntity>>> ListarAsync(int page = 1, int pageSize = 10000, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await DbSet
                .Skip(((page - 1) * pageSize))
                .Take((pageSize + 1))
                .OrderBy(x => x.Id)
                .ToListAsync(cancellationToken);

            return new Page<TEntity>(result, pageSize);
        }
    }
}