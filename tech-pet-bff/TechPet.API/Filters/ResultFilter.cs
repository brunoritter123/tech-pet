using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using TechPet.API.Responses;
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
                //context.HttpContext.Request.Headers["x-correlation-id"]
                var response = new ErrorResponse(_notificacao);
                context.Result = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(response),
                    StatusCode = response.Code,
                    ContentType = "application/json"
                };
            }
            await next();
        }
    }
}
