namespace TechPet.Domain.Abstractions.Repository
{
    public interface IRepository<TEntity, in TId> : IReadRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        Task<TEntity?> AddAsync(TEntity entity);

        Task DeleteAsync(TId id);

        Task UpdateAsync(TEntity entity);

    }
}
