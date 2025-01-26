// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Filters;
// using Microsoft.AspNetCore.Mvc.ModelBinding;
// using Newtonsoft.Json;
// using System.Text.RegularExpressions;
// using Pressur.API.Responses;
// using Pressur.Domain.Abstractions.FluentResults;
//
// namespace Pressur.API.Filters
// {
//     public class JsonErrorActionFilter : IActionFilter
//     {
//
//         public void OnActionExecuted(ActionExecutedContext context) { }
//
//         public void OnActionExecuting(ActionExecutingContext context)
//         {
//             if (context.Result == null && !context.ModelState.IsValid
//                 && HasJsonErrors(context.ModelState, out var appErros))
//             {
//
//                 var errorResponse = ErrorResponse.FromAppErros(appErros);
//
//                 context.Result = new ContentResult
//                 {
//                     Content = JsonConvert.SerializeObject(errorResponse),
//                     StatusCode = 400,
//                     ContentType = "application/json"
//                 };
//             }
//         }
//
//         private bool HasJsonErrors(ModelStateDictionary modelState, out List<AppErro> appErros)
//         {
//             appErros = new List<AppErro>();
//
//             foreach (var campoJson in modelState.Keys)
//             {
//                 var entry = modelState.GetValueOrDefault(campoJson, null);
//                 if (entry == null) continue;
//
//
//                 foreach (var error in entry.Errors)
//                 {
//                     var erroTraduzido = TraducaoMensagem(error.ErrorMessage, campoJson);
//                     appErros.Add(new AppErro($"Campo '{campoJson}' está inválido!", erroTraduzido, ErroTipo.Validacao));
//                 }
//             }
//             return appErros.Any();
//         }
//
//         private string TraducaoMensagem(string mensagem, string nomeCampo)
//         {
//             switch (mensagem)
//             {
//                 case var msg when new Regex(@"The .* field is required\.").IsMatch(msg):
//                     return $"É obrigatório informar um valor para o campo {nomeCampo}.";
//
//                 default:
//                     return mensagem;
//             }
//         }
//     }
// }
