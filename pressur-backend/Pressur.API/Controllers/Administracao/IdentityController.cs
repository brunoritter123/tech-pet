using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pressur.API.Abstractions.Extensions;
using Pressur.API.Responses;
using Pressur.Application.Features.Usuarios.Logar;
using Pressur.Application.Features.Usuarios.Registrar;

namespace Pressur.API.Controllers.Administracao
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [HttpPost("Registrar")]
        [ProducesResponseType(typeof(RegistrarUsuarioResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar(
            [FromBody] RegistrarUsuarioCommand command,
            [FromServices] IRegistrarUsuarioHandler useCase,
            CancellationToken cancellationToken)
        {
            var result = await useCase.ExecutarAsync(command, cancellationToken);
            return result.ToActionResult();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(typeof(LogarUsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(
            [FromBody] LogarUsuarioCommand command,
            [FromServices] ILogarUsuarioHandler useCase,
            CancellationToken cancellationToken)
        {
            var result = await useCase.ExecutarAsync(command, cancellationToken);
            return result.ToActionResult();
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
