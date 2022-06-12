using Microsoft.Extensions.Logging;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Identity.DTOs;
using TechPet.Identity.Entities;

namespace TechPet.Application.Extensions.Identity.NotifyIdentityErrors
{
    public static class NotifyIdentityErrorsExtension
    {
        public static void AddNotificationsIdentity(this INotificacaoService notificacaoService, IEnumerable<ErroIdentityDto> erros, User user, ILogger logger)
        {
            foreach (var erro in erros)
            {
                AddNotification(notificacaoService, erro.Codigo, erro.Menssagem, user, logger);
            }
        }

        private static void AddNotification(INotificacaoService notificacaoService, string codeMensage, string identityMensage, User user, ILogger logger)
        {
            switch (codeMensage)
            {
                case "DuplicateUserName":
                    notificacaoService.AddNotificacao($"Já existe um cadastro com o login {user.UserName}.");
                    break;

                default:
                    notificacaoService.AddNotificacaoErroInterno();
                    logger?.LogError($"Não foi possível realizar a operação: {identityMensage}");
                    break;
            }
        }
    }
}
