using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pressur.API.Abstractions.Extensions;
using Pressur.Application.Features.Empresas.IncluirEmpresa;

namespace Pressur.API.Controllers.Administracao
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        [HttpPost()]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IncluirEmpresaResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Incluir(
            [FromBody] IncluirEmpresaCommand command,
            [FromServices] IIncluirEmpresaHandler useCase,
            CancellationToken cancellationToken)
        {
            var result = await useCase.ExecutarAsync(command, cancellationToken);
            return result.ToActionResult();
        }

        // [HttpGet()]
        // [Authorize(Roles = "Admin")]
        // [ProducesResponseType(typeof(IncluirEmpresaResponse), StatusCodes.Status200OK)]
        // public async Task<IActionResult> Listar(
        //     [FromBody] ListarEmpresaQuery request,
        //     [FromServices] IMediator mediator,
        //     CancellationToken cancellationToken)
        // {
        //     var result Ok(await mediator.Send(request));
        //     return result.ToActionResult();
        // }

        // [HttpGet("{id}")]
        // [Authorize(Roles = "Admin")]
        // [ProducesResponseType(typeof(IncluirEmpresaResponse), StatusCodes.Status200OK)]
        // public async Task<IActionResult> Buscar(
        //     Guid id,
        //     [FromServices] IMediator mediator)
        // {
        //     return Ok(await mediator.Send(new BuscarEmpresaQuery(id)));
        // }
    }
}