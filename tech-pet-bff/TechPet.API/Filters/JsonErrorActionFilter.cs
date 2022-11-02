using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using TechPet.API.Responses;
using TechPet.Domain.Abstractions.Notifications;

namespace TechPet.API.Filters
{
    public class JsonErrorActionFilter : IActionFilter, IOrderedFilter
    {

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Result == null && !context.ModelState.IsValid
                && HasJsonErrors(context.ModelState, out var notificacaosDeErro))
            {

                var errorResponse = new ErrorResponse(notificacaosDeErro);

                context.Result = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(errorResponse),
                    StatusCode = 400,
                    ContentType = "application/json"
                };
            }
        }

        private bool HasJsonErrors(ModelStateDictionary modelState, out List<Notificacao> notificacaosDeErro)
        {
            notificacaosDeErro = new List<Notificacao>();

            foreach (var campoJson in modelState.Keys)
            {
                var entry = modelState.GetValueOrDefault(campoJson, null);
                if (entry == null) continue;


                foreach (var error in entry.Errors)
                {
                    var erroTraduzido = TraducaoMensagem(error.ErrorMessage, campoJson);
                    notificacaosDeErro.Add(new Notificacao($"Campo '{campoJson}' está inválido!", erroTraduzido, NotificacaoTipo.Validacao));
                }
            }
            return notificacaosDeErro.Any();
        }

        private string TraducaoMensagem(string mensagem, string nomeCampo)
        {
            switch (mensagem)
            {
                case var msg when new Regex(@"The .* field is required\.").IsMatch(msg):
                    return $"É obrigatório informar um valor para o campo {nomeCampo}.";

                default:
                    return mensagem;
            }
        }

        // Set to a large negative value so it runs earlier than ModelStateInvalidFilter
        public int Order => -200000;
    }
}
