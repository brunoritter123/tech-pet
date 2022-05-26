using TechPet.Domain.Abstractions;
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
            notificacaoService.AddErro($"Não foi possível incluir '{entitidadeComErro.GetType()}', pois já existe '{entitidadeComErro}' com o identificador {entitidadeComErro.Id}", "Id");
        }

        public static void AddErroEntidadeNaoExistenteAoAlterar<T>(
            this INotificacaoService notificacaoService,
            Entity<T> entitidadeComErro)
            where T : struct
        {
            notificacaoService.AddErro($"Não foi possível alterar '{entitidadeComErro.GetType()}', pois não existe '{entitidadeComErro}' com o identificador {entitidadeComErro.Id}", "Id");
        }
    }
}
