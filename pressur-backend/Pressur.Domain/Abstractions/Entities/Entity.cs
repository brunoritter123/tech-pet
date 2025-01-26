namespace Pressur.Domain.Abstractions.Entities;
public abstract class Entity<T> : Entity
    where T : struct
{
    public T Id { get; protected set; }
}

public abstract class Entity
{
    public string CodigoEmpresa { get; protected set; } = null!;
}
