using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Domain.Abstractions.Entities;
using TechPet.Domain.Abstractions.FluentResults;
using TechPet.Domain.Abstractions.Notifications;

namespace TechPet.Domain.Abstractions.Commands
{
    public abstract class CommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        protected Result<bool> NotifyIfEntityInvalid(Entity entity)
        {
            if (!entity.Valido())
            {
                _notificacaoService.AddNotificacao(
                    $"Não foi possível registrar {entity.GetNomeDaEntitidadeAmigavel().GetNomeComArtigo()}.",
                    "Um ou mais campos estão inválidos.",
                    entity.GetErros());
                return true;
            }
            return false;
        }
    }
}
