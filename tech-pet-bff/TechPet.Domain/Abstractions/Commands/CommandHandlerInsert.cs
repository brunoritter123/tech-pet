using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Domain.Abstractions.Entities;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Abstractions.Repository;

namespace TechPet.Domain.Abstractions.Commands
{
    public abstract class CommandHandlerInsert<TRequest, TResponse, TEntity, TEntityId> : CommandHandler<TRequest, TResponse?>
        where TRequest : IRequest<TResponse>
        where TEntity : Entity<TEntityId>
        where TEntityId : struct
    {
        protected readonly IRepository<TEntity, TEntityId> _repository;

        protected CommandHandlerInsert(INotificacaoService notificacaoService, IRepository<TEntity, TEntityId> repository)
            : base (notificacaoService)
        {
            _repository = repository;
        }

        public override async Task<TResponse?> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (!ValidCommand(request))
                return default;

            var entity = CommandToEntity(request);
            if (NotifyIfEntityInvalid(entity))
                return default;

            var resultRepository = await _repository.AddAsync(entity);

            return ResultRepositoryToResponse(resultRepository);
        }

        protected abstract TEntity CommandToEntity(TRequest command);
        protected abstract bool ValidCommand(TRequest command);
        protected abstract TResponse ResultRepositoryToResponse(TEntity? entity);
    }
}
