using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechPet.Domain.Entities.Empresas.Queries.BuscarEmpresa;
using TechPet.Domain.Entities.Empresas.Queries.ListarEmpresa;
using TechPet.Domain.Entities.Empresas.Results;
using TechPet.UseCase.UseCases.Empresas.IncluirEmpresa;

namespace TechPet.API.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        [HttpPost()]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(EmpresaResult), StatusCodes.Status201Created)]
        public async Task<IActionResult> Incluir(
            [FromBody] IncluirEmpresaRequest request,
            [FromServices] IIncluirEmpresaUseCase useCase)
        {
            return Created("Empresa", await useCase.ExecutarAsync(request));
        }

        [HttpGet()]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(EmpresaResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(
            [FromBody] ListarEmpresaQuery request,
            [FromServices] IMediator mediator)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(EmpresaResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Buscar(
            Guid id,
            [FromServices] IMediator mediator)
        {
            return Ok(await mediator.Send(new BuscarEmpresaQuery(id)));
        }
    }
}