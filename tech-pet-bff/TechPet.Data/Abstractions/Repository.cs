using Microsoft.EntityFrameworkCore;
using TechPet.Data.Abstractions.Extensions;
using TechPet.Domain.Abstractions;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Abstractions.Repository;

namespace TechPet.Data.Abstractions
{
    public abstract class Repository<TEntity, TId> : ReadRepository<TEntity, TId>, IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        protected readonly DbContext _dbContext;
        protected readonly INotificacaoService _notificacaoService;
        protected Repository(DbContext dbContext, INotificacaoService notificacaoService) : base(dbContext)
        {
            _dbContext = dbContext;
            _notificacaoService = notificacaoService;
        }

        public virtual async Task<TEntity?> AddAsync(TEntity entity)
        {
            if (entity is null) return null;
            if (!entity.Valido()) return null;
            if (await ExisteAsync(entity.Id))
            {
                _notificacaoService.AddErroEntidadeExistenteAoAdicionar(entity);
                return null;
            }

            var novaEntidade = await _dbContext.AddAsync(entity);
            return novaEntidade.Entity;
        }

        public virtual async Task DeleteAsync(TId id)
        {
            if (Equals(id, default(TId)) is true) return;

            var entity = await BuscarPorIdAsTrackingAsync(id);
            if (entity is null) return;
            _dbContext.Remove(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity is null) return;
            if (!entity.Valido()) return;
            if (!(await ExisteAsync(entity.Id)))
            {
                _notificacaoService.AddErroEntidadeNaoExistenteAoAlterar(entity);
                return;
            }

            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
