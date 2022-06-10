using TechPet.Domain.Abstractions.Entities;
using TechPet.Domain.Abstractions.Notifications;

namespace TechPet.Data.Abstractions.Extensions
{
    public static class NotificacaoServiceDataExtensions
    {
        public static void AddErroEntidadeExistenteAoAdicionar<T>(
            this INotificacaoService notificacaoService,
            Entity<T> entitidadeComErro)
            where T : struct
        {
            notificacaoService.AddNotificacao(
                $"Não foi possível incluir '{entitidadeComErro.GetType()}'",
                $"Já existe '{entitidadeComErro}' com o identificador {entitidadeComErro.Id}");
        }

        public static void AddErroEntidadeNaoExistenteAoAlterar<T>(
            this INotificacaoService notificacaoService,
            Entity<T> entitidadeComErro)
            where T : struct
        {
            notificacaoService.AddNotificacao(
                $"Não foi possível alterar '{entitidadeComErro.GetType()}'",
                $"Não existe '{entitidadeComErro}' com o identificador {entitidadeComErro.Id}");
        }
    }
}
