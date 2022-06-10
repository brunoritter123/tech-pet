using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Identity.DTOs;

namespace TechPet.UseCase.Services.Identity.NotifyIdentityErrors
{
    public class NotifyIdentityErrorsService : INotifyIdentityErrorsService
    {
        protected readonly INotificacaoService _notificacaoService;
        protected readonly ILogger<NotifyIdentityErrorsService> _logger;

        public NotifyIdentityErrorsService(INotificacaoService notificacaoService, ILogger<NotifyIdentityErrorsService> logger)
        {
            _notificacaoService = notificacaoService;
            _logger = logger;
        }

        public void AddNotifications(IEnumerable<ErroIdentityDto> erros)
        {
            foreach (var erro in erros)
            {
                AddNotification(erro.Codigo, erro.Menssagem);
            }
        }

        private void AddNotification(string codeMensage, string identityMensage)
        {
            switch (codeMensage)
            {
                case "DuplicateUserName":
                    _notificacaoService.AddNotificacao("Já existe um cadastro com o login selecionado.");
                    break;

                default:
                    _notificacaoService.AddNotificacaoErroInterno();
                    _logger.LogError($"Não foi possível realizar a operação: {identityMensage}");
                    break;
            }
        }
    }
}
