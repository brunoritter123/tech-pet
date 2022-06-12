using Microsoft.Extensions.Logging;
using TechPet.Application.Extensions.Identity.NotifyIdentityErrors;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Identity.Entities;
using TechPet.Identity.Interfaces;

namespace TechPet.Application.Commands.IncluirUsers
{
    internal class IncluirUsersCommand : IIncluirUsersCommand
    {
        public List<User> usersCriados { get; private set; }
        private readonly IIdentityService _identityService;
        private readonly INotificacaoService _notificacaoService;
        private readonly ILogger _logger;

        public IncluirUsersCommand(IIdentityService identityService, INotificacaoService notificacaoService, ILogger<IncluirUsersCommand> logger)
        {
            usersCriados = new List<User>();
            _identityService = identityService;
            _notificacaoService = notificacaoService;
            _logger = logger;
        }

        public async Task<bool> ExecuteAsync(IEnumerable<IncluirUsersCommandRequest> requests)
        {
            foreach (var request in requests)
            {
                var result = await _identityService.CriarUsuarioAsync(request.User, request.Senha);

                if (!result.Sucesso)
                {
                    _notificacaoService.AddNotificationsIdentity(result.Erros, request.User, _logger);
                    await UndoAsync();
                    return false;
                }
                usersCriados.Add(request.User);
            }
            return true;
        }

        public async Task UndoAsync()
        {
            foreach (var userIdentity in usersCriados)
            {
                var result = await _identityService.ExcluirUsuarioAsync(userIdentity);

                if (!result.Sucesso)
                {
                    _notificacaoService.AddNotificationsIdentity(result.Erros, userIdentity, _logger);
                }
            }
        }
    }
}
