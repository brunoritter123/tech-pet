using Microsoft.Extensions.Logging;
using TechPet.Data.Context;
using TechPet.Domain.Abstractions.Notifications;

namespace TechPet.Application.Commands.CriarNovoBancoDeDados
{
    internal class CriarNovoBancoDeDadosCommand : ICriarNovoBancoDeDadosCommand
    {
        private readonly INotificacaoService _notificacaoService;
        private readonly ILogger<CriarNovoBancoDeDadosCommand> _logger;

        public readonly TechPetContext Context;
        public string NomeDataBase { get; private set; }

        public CriarNovoBancoDeDadosCommand(TechPetContext context, INotificacaoService notificacaoService, ILogger<CriarNovoBancoDeDadosCommand> logger)
        {
            Context = context;
            _notificacaoService = notificacaoService;
            _logger = logger;
            NomeDataBase = null!;
        }

        public Task<bool> ExecuteAsync(string request)
        {
            NomeDataBase = request;

            try
            {
                Context.CreateDataBase(NomeDataBase);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _notificacaoService.AddNotificacaoErroInterno();
                _logger.LogError(ex, $"Erro inesperado ao tentar criar o banco de dados para empresa {NomeDataBase}.");
                return Task.FromResult(false);
            }
        }

        public Task UndoAsync()
        {
            try
            {
                Context.DropDataBase();
            }
            catch (Exception ex)
            {
                _notificacaoService.AddNotificacaoErroInterno();
                _logger.LogCritical(ex, $"Erro inesperado ao tentar remover o banco de dados da empresa {NomeDataBase}.");
            }

            return Task.CompletedTask;
        }
    }
}
