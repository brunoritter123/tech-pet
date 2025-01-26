using Microsoft.EntityFrameworkCore;
using Pressur.Data.Context;
using Pressur.Domain.Abstractions.Entities;
using Pressur.Domain.Abstractions.FluentResults;
using Pressur.Domain.Abstractions.Repository;

namespace Pressur.Data.Abstractions
{
    public abstract class Repository<TEntity, TId> : ReadRepository<TEntity, TId>, IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        private readonly DbContext _dbContext;
        protected Repository(PressurContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<Result<TEntity>> AddAsync(TEntity entity, bool saveChanges = false)
        {
            var resultExiste = await ExisteAsync(entity.Id);
            if (!resultExiste.Sucesso)
                return Result<TEntity>.FromResultFail(resultExiste);
            
            if (resultExiste.GetResultSucesso())
                return Result<TEntity>.Fail(
                    "ErroInclusaoItem",
                    $"Não foi possível incluir '{entity.GetType()}'", 
                    ErroTipo.Error,
                    $"Já existe '{entity}' com o identificador {entity.Id}");

            var novaEntidade = await _dbContext.AddAsync(entity);
            
            if (saveChanges)
                await _dbContext.SaveChangesAsync();

            return novaEntidade.Entity;
        }

        public virtual async Task<Result> DeleteAsync(TId id, bool saveChanges = false)
        {
            var resultEntity = await BuscarPorIdAsTrackingAsync(id);
            if (!resultEntity.Sucesso)
                return Result<TEntity>.FromResultFail(resultEntity);

            if (resultEntity.GetOpcionalResultSucesso() is not null)
            {
                _dbContext.Remove(resultEntity.GetResultSucesso());
                
                if (saveChanges)
                    await _dbContext.SaveChangesAsync();
            }
            

            return new Result();
        }

        public virtual async Task<Result> UpdateAsync(TEntity entity, bool saveChanges = false)
        {
            var resultExiste = await ExisteAsync(entity.Id);
            if (!resultExiste.Sucesso)
                return Result<TEntity>.FromResultFail(resultExiste);
            
            if (resultExiste.GetResultSucesso())
                return Result<TEntity>.Fail(
                    "ErroAtualizacaoItem",
                    $"Não foi possível alterar '{entity.GetType()}'",
                    ErroTipo.Error,
                    $"Não existe '{entity}' com o identificador {entity.Id}");

            _dbContext.Entry(entity).State = EntityState.Modified;
            
            if (saveChanges)
                await _dbContext.SaveChangesAsync();

            return new Result();
        }
    }
}
