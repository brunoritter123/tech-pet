using FluentValidation;
using TechPet.Domain.Abstractions.Validacoes;

namespace TechPet.Domain.Abstractions.Entities
{
    public abstract class Entity<T> : Entity
        where T : struct
    {
        public T Id { get; private set; }
    }

    public abstract class Entity : ObjetoValidavel
    {
        protected bool OnValidate<TValidador, TEntity>(TEntity entity, TValidador validador)
            where TValidador : AbstractValidator<TEntity>
            where TEntity : Entity
        {
            AddError(validador.Validate(entity));
            return Valido();
        }

        public abstract NomeAmigavelDaEntitidade GetNomeDaEntitidadeAmigavel();
    }
}
