namespace TechPet.Domain.Abstractions.Repository
{
    public interface IReadRepository<TEntity, in TId>
        where TEntity : Entity
        where TId : struct
    {
        Task<bool> ExisteAsync(TId id);

        Task<TEntity?> BuscarPorIdAsync(TId id);

        Task<TEntity?> BuscarPorIdAsTrackingAsync(TId id);
    }
}
