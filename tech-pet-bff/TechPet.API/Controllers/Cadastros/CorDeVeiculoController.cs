using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechPet.Domain.Abstractions.Paginacao;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Commads;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Results;

namespace TechPet.API.Controllers.Cadastros
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CorDeVeiculoController : ControllerBase
    {
        [HttpGet()]
        [ProducesResponseType(typeof(Page<CorDeVeiculoResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar([FromServices] IMediator mediator)
        {
            var results = await mediator.Send(new ListarCorDeVeiculoQuery());
            return Ok(results);
        }
    }
}
