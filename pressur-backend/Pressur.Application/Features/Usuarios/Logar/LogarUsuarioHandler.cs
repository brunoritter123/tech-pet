using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pressur.Domain.Abstractions.FluentResults;
using Pressur.Identity.Interfaces;

namespace Pressur.Application.Features.Usuarios.Logar;

public class LogarUsuarioHandler : ILogarUsuarioHandler
{
    private readonly IIdentityService _identityService;
    private readonly ILogger<LogarUsuarioHandler> _logger;
    private readonly IJwtService _jwtService;
    private readonly IConfiguration _configuration;

    public LogarUsuarioHandler(
        ILogger<LogarUsuarioHandler> logger, 
        IIdentityService identityService,
        IJwtService jwtService,
        IConfiguration configuration)
    {
        _logger = logger;
        _identityService = identityService;
        _jwtService = jwtService;
        _configuration = configuration;
    }

    public async Task<Result<LogarUsuarioResponse>> ExecutarAsync(LogarUsuarioCommand command, CancellationToken cancellationToken)
    {
        var userResult = await _identityService.BuscarPorUserNameAsync(command.Login);
        if (!userResult.Sucesso)
        {
            _logger.LogDebug("Usuário não encontrado para o userName: {}", command.Login);
            return Result<LogarUsuarioResponse>.Fail("UsuarioNaoAutorizado", "Usuário não autorizado", ErroTipo.Autenticacao);
        }

        var loginResult = await _identityService.ValidarSenhaAsync(userResult.GetResultSucesso(), DecodeBase64(command.Password));
        if (!loginResult.Sucesso)
        {
            _logger.LogInformation("Tentativa de login incorreto para o userName: {}", command.Login);
            return Result<LogarUsuarioResponse>.Fail("UsuarioNaoAutorizado", "Usuário não autorizado", ErroTipo.Autenticacao);
        }


        //var usuario = await _repository.BuscarPorLoginAsync(request.Login);
        //if (usuario is null)
        //{
        //    _notificacaoService.AddNotificacaoErroInterno();
        //    _logger.LogError($"Não foi possível encontrar um perfil para o usuário: {request.Login}");
        //    return null;
        //}

        //var usuarioResult = usuario.ToUsuarioResult();
        var identity = userResult.GetResultSucesso();

        var roleAdmin = SeUsuarioEAdmin(identity.UserName!) ? new List<string>() { "Admin" } : null;
        var token = _jwtService.GenerateJWToken(identity, roleAdmin);

        return new LogarUsuarioResponse()
        {
            Token = token,
            User = new LogarUsuarioResponse.Usuario()
            {
                Nome = identity.Nome,
                Login = identity.UserName!,
                Email = identity.Email!
            }
        };
    }

    private bool SeUsuarioEAdmin(string login)
    {
        var admins = _configuration.GetSection("Admins").Get<List<string>>();
        return admins != null && admins.Contains(login);
    }

    private static string DecodeBase64(string senha)
    {
        var data = Convert.FromBase64String(senha);
        return Encoding.UTF8.GetString(data);
    }
}
