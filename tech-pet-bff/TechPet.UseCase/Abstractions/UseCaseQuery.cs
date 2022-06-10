using Microsoft.Extensions.Logging;
using TechPet.Domain.Abstractions.Notifications;

namespace TechPet.UseCase.Abstractions
{
    public abstract class UseCaseQuery<TRequest, TResult> : IUseCase<TRequest, TResult>
    {
        protected readonly ILogger<UseCaseQuery<TRequest, TResult>> _logger;
        protected readonly INotificacaoService _notificacaoService;

        public UseCaseQuery(INotificacaoService notificacaoService, ILogger<UseCaseQuery<TRequest, TResult>> logger)
        {
            _notificacaoService = notificacaoService;
            _logger = logger;
        }

        public async Task<TResult?> ExecutarAsync(TRequest request)
        {
            try
            {
                var result = await AoExecutarAsync(request);

                if (_notificacaoService.ExisteNotificacao()) return result;

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
}
