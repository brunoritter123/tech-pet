using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechPet.API.Results;
using TechPet.Domain.Entities.Usuarios;
using TechPet.Domain.Entities.Usuarios.Commands.RegistrarUsuario;
using TechPet.UseCase.Requests;
using TechPet.UseCase.UseCases.Usuarios;
using TechPet.UseCase.UseCases.Usuarios.Logar;
using TechPet.UseCase.UseCases.Usuarios.Registrar;

namespace TechPet.API.Controllers
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [HttpPost("Registrar")]
        [ProducesResponseType(typeof(ResultDefault<UsuarioResult>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar(
            [FromBody] RegistrarUsuarioCommand request,
            [FromServices] IRegistrarUsuarioUseCase useCase)
        {
            var result = await useCase.ExecutarAsync(request);
            return Created("Login", new ResultDefault<UsuarioResult>(result));
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(ResultDefault<UsuarioResult>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Login(
            [FromBody] UsuarioLoginRequest request,
            [FromServices] ILogarUsuarioUseCase useCase)
        {
            var result = await useCase.ExecutarAsync(request);
            return Ok(new ResultDefault<UsuarioResult>(result));

            //var result = await _usuarioService.LoginAsync(userLogin);
            //if (!result.Sucesso)
            //    return Unauthorized(result.Erros.First());

            //return Ok(new
            //{
            //    token = GenerateJWToken(result.Resultado),
            //    user = result.Resultado
            //});
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
