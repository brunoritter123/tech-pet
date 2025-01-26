using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pressur.API.Abstractions.Extensions;
using Pressur.Domain.Abstractions.FluentResults;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;

namespace Pressur.API.Configurations;

public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
{
    public IActionResult CreateActionResult(ActionExecutingContext context, ValidationProblemDetails? validationProblemDetails)
    {
             var appErros = context.ModelState.Values
                 .SelectMany(entry => entry.Errors
                     .Select(error => new AppErro("ValidacaoRequest", error.ErrorMessage, ErroTipo.Validacao)));
             
             return new Result(appErros).ToActionResult();
    }
}