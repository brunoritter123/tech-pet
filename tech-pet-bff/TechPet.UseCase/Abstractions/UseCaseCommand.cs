using MediatR;
using Microsoft.Extensions.Logging;
using TechPet.Data.Abstractions;
using TechPet.Domain.Abstractions.Notifications;

namespace TechPet.UseCase.Abstractions
{
    public abstract class UseCaseCommand<TRequest, TResult> : IUseCase<TRequest, TResult>
    {
        protected readonly ILogger<UseCaseCommand<TRequest, TResult>> _logger;
        protected readonly IMediator _mediator;
        protected readonly INotificacaoService _notificacaoService;
        private readonly IUnitOfWork _unitOfWork;

        public UseCaseCommand(INotificacaoService notificacaoService, IMediator mediator, IUnitOfWork unitOfWork, ILogger<UseCaseCommand<TRequest, TResult>> logger)
        {
            _notificacaoService = notificacaoService;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public virtual async Task<TResult?> ExecutarAsync(TRequest request)
        {
            try
            {
                var result = await AoExecutarAsync(request);

                if (_notificacaoService.ExisteNotificacao()) return default;

                await _unitOfWork.CommitAsync();

                return result;

            }
            catch (Exception ex)
            {
                _notificacaoService.AddNotificacaoErroInterno();
                _logger.LogError(ex, "Erro inesperado ao processar a requisição.");

                return default;
            }
        }

        protected abstract Task<TResult?> AoExecutarAsync(TRequest request);

    }

    public abstract class UseCaseCommand<TResult> : UseCaseCommand<bool, TResult>, IUseCase<TResult>
    {
        protected UseCaseCommand(INotificacaoService notificacaoService, IMediator mediator, IUnitOfWork unitOfWork, ILogger<UseCaseCommand<bool, TResult>> logger)
           : base(notificacaoService, mediator, unitOfWork, logger)
        {
        }

        public Task<TResult?> ExecutarAsync()
            => base.ExecutarAsync(true);

        protected override Task<TResult?> AoExecutarAsync(bool request)
            => AoExecutarAsync();

        protected abstract Task<TResult?> AoExecutarAsync();

    }
}
