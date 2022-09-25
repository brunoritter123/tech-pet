using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechPet.Domain.Abstractions.Paginacao;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Queries.ListarCorDeVeiculo;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Results;
using TechPet.UseCase.UseCases.CoresDeVeiculo.ListarCoresDeVeiculo;

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
        public async Task<IActionResult> Listar([FromServices] IListarCoresDeVeiculoUseCase useCase)
        {
            var results = await useCase.ExecutarAsync();
            return Ok(results);
        }
    }
}
