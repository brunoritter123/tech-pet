using Microsoft.AspNetCore.Mvc;
using Pressur.API.Responses;
using Pressur.Domain.Abstractions.FluentResults;

namespace Pressur.API.Abstractions.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        if (result.Sucesso)
            return new OkObjectResult(result.GetOpcionalResultSucesso());

        var listErros = result.GetErros().ToList();
        var firstAppErro = listErros.FirstOrDefault() ?? throw new NullReferenceException();
        var responseErro = ErrorResponse.FromAppErros(listErros);

        var statusCode = firstAppErro.ErroTipo switch
        {
            ErroTipo.Validacao => StatusCodes.Status400BadRequest,
            ErroTipo.Error => StatusCodes.Status500InternalServerError,
            ErroTipo.Autenticacao  => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };

        return new ObjectResult(responseErro)
        {
            StatusCode = statusCode
        };
    }
    
    public static IActionResult ToActionResult(this Result result)
    {
        if (result.Sucesso)
            return new NoContentResult();
        
        var listErros = result.GetErros().ToList();
        var firstAppErro = listErros.FirstOrDefault() ?? throw new NullReferenceException();
        var responseErro = ErrorResponse.FromAppErros(listErros);

        var statusCode = firstAppErro.ErroTipo switch
        {
            ErroTipo.Validacao => StatusCodes.Status400BadRequest,
            ErroTipo.Error => StatusCodes.Status500InternalServerError,
            ErroTipo.Autenticacao  => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };

        return new ObjectResult(responseErro)
        {
            StatusCode = statusCode
        };
    }
}