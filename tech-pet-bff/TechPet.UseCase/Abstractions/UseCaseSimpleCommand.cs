using MediatR;
using Microsoft.Extensions.Logging;
using TechPet.Data.Abstractions;
using TechPet.Domain.Abstractions.Notifications;

namespace TechPet.UseCase.Abstractions
{
    public abstract class UseCaseSimpleCommand<TRequest, TResult> : UseCaseCommand<TRequest, TResult>
        where TRequest : IRequest<TResult>
    {
        protected UseCaseSimpleCommand(INotificacaoService notificacaoService, IMediator mediator, IUnitOfWork unitOfWork, ILogger<UseCaseCommand<TRequest, TResult>> logger) : base(notificacaoService, mediator, unitOfWork, logger)
        {
        }

        protected async override Task<TResult?> AoExecutarAsync(TRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}