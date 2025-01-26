using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pressur.API.Abstractions.Extensions;
using Pressur.Application.Features.CoresDeVeiculo.ListarCoresDeVeiculo;
using Pressur.Domain.Abstractions.Paginacao;

namespace Pressur.API.Controllers.Cadastros
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CorDeVeiculoController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(Page<ListarCoresDeVeiculoResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(
            [FromServices] IListarCoresDeVeiculoHandler useCase,
            CancellationToken cancellationToken)
        {
            var result = await useCase.ExecutarAsync(cancellationToken);
            return result.ToActionResult();
        }
    }
}
