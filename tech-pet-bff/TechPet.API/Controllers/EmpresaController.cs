using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechPet.Domain.Entities.Empresas.Commands.IncluirEmpresa;
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
        public async Task<IActionResult> Registrar(
            [FromBody] IncluirEmpresaCommand request,
            [FromServices] IIncluirEmpresaUseCase useCase)
        {
            return Created("Empresa", await useCase.ExecutarAsync(request));
        }
    }
}
