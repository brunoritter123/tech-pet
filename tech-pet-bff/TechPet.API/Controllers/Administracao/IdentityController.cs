using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechPet.API.Responses;
using TechPet.Domain.Entities.Usuarios;
using TechPet.Domain.Entities.Usuarios.Commands.RegistrarUsuario;
using TechPet.UseCase.UseCases.Usuarios.Logar;
using TechPet.UseCase.UseCases.Usuarios.Registrar;
using TechPet.UseCase.Usuarios.Logar;

namespace TechPet.API.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [HttpPost("Registrar")]
        [ProducesResponseType(typeof(UsuarioResult), StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar(
            [FromBody] RegistrarUsuarioCommand request,
            [FromServices] IRegistrarUsuarioUseCase useCase)
        {
            return Created("Login", await useCase.ExecutarAsync(request));
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(typeof(LogarUsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Login(
            [FromBody] LogarUsuarioRequest request,
            [FromServices] ILogarUsuarioUseCase useCase)
        {
            return Ok(await useCase.ExecutarAsync(request));
        }

        //[HttpPost("resetar-senha")]
        //public async Task<ActionResult> ResetarSenha(UserResetarSenhaRequest userResetarSenha)
        //{
        //    var result = await _usuarioService.ResetarSenhaAsync(userResetarSenha);
        //    if (!result.Sucesso) return BadRequest(result.Erros);

        //    return NoContent();
        //}

        //[HttpPost("confirmar-email")]
        //public async Task<ActionResult> ConfirmarEmail(UserConfirmaEmailRequest userEmail)
        //{
        //    var result = await _usuarioService.ConfirmarEmailAsync(userEmail.UserName, userEmail.Token);
        //    if (!result.Sucesso) return BadRequest(result.Erros);

        //    return Ok(new
        //    {
        //        token = GenerateJWToken(result.Resultado),
        //        user = result.Resultado
        //    });
        //}

        //[HttpPost("enviar-confirmacao-email/{userName}")]
        //public async Task<ActionResult> EnviarConfirmacaoEmail(string userName, [FromQuery] ConfirmacaoEmailRequest dto)
        //{
        //    var resultado = await _usuarioService.EnviarConfirmacaoEmailAsync(userName, dto.UrlConfirmaEmail);
        //    if (!resultado.Sucesso)
        //        return BadRequest(resultado.Erros);

        //    return NoContent();
        //}

        //[HttpPost("solicitacao-resetar-senha/{userName}")]
        //public async Task<ActionResult> SolicitacaoResetarSenha(string userName, [FromQuery] ResetarSenhaRequest dto)
        //{
        //    await _usuarioService.SolicitarResetDeSenhaAsync(userName, dto.UrlCallback);
        //    return NoContent();
        //}
    }
}
