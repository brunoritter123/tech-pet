using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using TechPet.API.Results;
using TechPet.Domain.Abstractions.Notifications;

namespace TechPet.API.Filters
{
    public class ResultFilter : IAsyncResultFilter
    {
        private readonly INotificacaoService _notificacao;
        public ResultFilter(INotificacaoService notificacao)
        {
            _notificacao = notificacao;
        }
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificacao.ExisteNotificacao())
            {
                var result = new ResultDefault(_notificacao.GetErros());
                context.Result = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(result),
                    StatusCode = DeParaStatusCode(_notificacao.GetTipoErro()),
                    ContentType = "application/json"
                };
            }
            await next();
        }

        private int DeParaStatusCode(NotificacaoTipo? tipo)
        {
            if (!tipo.HasValue) return 500;

            switch (tipo.Value)
            {
                case NotificacaoTipo.Validacao:
                    return StatusCodes.Status400BadRequest;

                case NotificacaoTipo.SemAcesso:
                    return StatusCodes.Status403Forbidden;

                case NotificacaoTipo.RecursoNaoEncontrado:
                    return StatusCodes.Status404NotFound;

                case NotificacaoTipo.ErroInterno:
                    return StatusCodes.Status500InternalServerError;

                default:
                    return 500;
            }
        }
    }
}
