using Microsoft.Extensions.Logging;
using System.Text;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Entities.Usuarios;
using TechPet.Domain.Entities.Usuarios.Repository;
using TechPet.Identity.Interfaces;
using TechPet.UseCase.Abstractions;
using TechPet.UseCase.Usuarios.Logar;
using Microsoft.Extensions.Configuration;
using TechPet.Domain.Entities.Usuarios.Mappers;

namespace TechPet.UseCase.UseCases.Usuarios.Logar
{
    public class LogarUsuarioUseCase : UseCaseQuery<LogarUsuarioRequest, LogarUsuarioResponse?>, ILogarUsuarioUseCase
    {
        private readonly IIdentityService _identityService;
        private readonly IUsuarioRepository _repository;
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _configuration;

        public LogarUsuarioUseCase(INotificacaoService notificacaoService, ILogger<LogarUsuarioUseCase> logger, IIdentityService identityService, IUsuarioRepository repository, IJwtService jwtService, IConfiguration configuration) : base(notificacaoService, logger)
        {
            _identityService = identityService;
            _repository = repository;
            _jwtService = jwtService;
            _configuration = configuration;
        }

        protected async override Task<LogarUsuarioResponse?> AoExecutarAsync(LogarUsuarioRequest request)
        {
            var userResult = await _identityService.BuscarPorUserNameAsync(request.Login);
            if (!userResult.Sucesso || userResult?.Resultado is null)
            {
                _notificacaoService.AddNotificacao("Login ou a senha estão inválidos.", tipo: NotificacaoTipo.ErroNasCredenciais);
                _logger.LogInformation($"Usuário não encontrado para o userName: {request.Login}");
                return default;
            }

            var loginResult = await _identityService.ValidarSenhaAsync(userResult.Resultado, DecodeBase64(request.Password));
            if (!loginResult.Sucesso)
            {
                _notificacaoService.AddNotificacao("Login ou a senha estão inválidos.", tipo: NotificacaoTipo.ErroNasCredenciais);
                _logger.LogInformation($"Tentativa de login incorreto para o userName: {request.Login}");
                return default;
            }


            var usuario = await _repository.BuscarPorLoginAsync(request.Login);
            if (usuario is null)
            {
                _notificacaoService.AddNotificacaoErroInterno();
                _logger.LogError($"Não foi possível encontrar um perfil para o usuário: {request.Login}");
                return null;
            }

            var usuarioResult = usuario.ToUsuarioResult();

            var roleAdmini = SeUsuarioEAdmini(userResult.Resultado.UserName) ? new List<string>() { "Admin" } : null;
            var token = _jwtService.GenerateJWToken(userResult.Resultado, roleAdmini);

            return new LogarUsuarioResponse(token, usuarioResult);
        }

        private bool SeUsuarioEAdmini(string login)
        {
            var admins = _configuration.GetSection("Admins").Get<List<string>>();
            return admins.Contains(login);
        }

        private string DecodeBase64(string senha)
        {
            byte[] data = Convert.FromBase64String(senha);
            return Encoding.UTF8.GetString(data);
        }
    }
}
