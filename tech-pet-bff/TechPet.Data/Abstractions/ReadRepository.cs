using Microsoft.EntityFrameworkCore;
using TechPet.Data.Context;
using TechPet.Domain.Abstractions.Entities;
using TechPet.Domain.Abstractions.Paginacao;
using TechPet.Domain.Abstractions.Repository;

namespace TechPet.Data.Abstractions
{
    public abstract class ReadRepository<TEntity, TId> : IReadRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        protected readonly DbSet<TEntity> _dbSet;

        protected ReadRepository(TechPetContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity?> BuscarPorIdAsync(TId id)
        {
            if (Equals(id, default(TId))) return null;
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => id.Equals(x.Id));
        }

        public virtual async Task<TEntity?> BuscarPorIdAsTrackingAsync(TId id)
        {
            if (Equals(id, default(TId))) return null;

            return await _dbSet.FindAsync(new object[] { id });
        }

        public virtual Task<bool> ExisteAsync(TId id)
            => _dbSet.AnyAsync(x => id.Equals(x.Id));

        public virtual async Task<Page<TEntity>> ListarAsync(int page = 1, int pageSize = 10000, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _dbSet
                .Skip(((page - 1) * pageSize))
                .Take((pageSize + 1))
                .OrderBy(x => x.Id)
                .ToListAsync(cancellationToken);

            return new Page<TEntity>(result, pageSize);
        }
    }
}