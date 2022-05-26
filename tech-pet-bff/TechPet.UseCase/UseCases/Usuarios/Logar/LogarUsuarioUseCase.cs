using Microsoft.Extensions.Logging;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Entities.Usuarios;
using TechPet.Domain.Entities.Usuarios.Repository;
using TechPet.Identity.Interfaces;
using TechPet.UseCase.Abstractions;
using TechPet.UseCase.Requests;

namespace TechPet.UseCase.UseCases.Usuarios.Logar
{
    public class LogarUsuarioUseCase : UseCaseQuery<UsuarioLoginRequest, UsuarioResult?>, ILogarUsuarioUseCase
    {
        private readonly IIdentityService _identityService;
        private readonly IUsuarioRepository _repository;

        public LogarUsuarioUseCase(INotificacaoService notificacaoService, ILogger<LogarUsuarioUseCase> logger, IIdentityService identityService, IUsuarioRepository repository) : base(notificacaoService, logger)
        {
            _identityService = identityService;
            _repository = repository;
        }

        protected async override Task<UsuarioResult?> AoExecutarAsync(UsuarioLoginRequest request)
        {
            var userResult = await _identityService.BuscarPorUserNameAsync(request.UserName);
            if (!userResult.Sucesso || userResult?.Resultado is null)
            {
                _notificacaoService.AddErro("Não foi possível realizar o login.", NotificacaoTipo.SemAcesso);
                _logger.LogInformation($"Usuário não encontrado para o userName: {request.UserName}");
                return default;
            }

            var loginResult = await _identityService.ValidarSenhaAsync(userResult.Resultado, request.Password);
            if (!loginResult.Sucesso)
            {
                _notificacaoService.AddErro("Não foi possível realizar o login.", NotificacaoTipo.SemAcesso);
                _logger.LogInformation($"Tentativa de login incorreto para o userName: {request.UserName}");
                return default;
            }


            var usuario = await _repository.BuscarPorLoginAsync(request.UserName);
            if (usuario is null)
            {
                _notificacaoService.AddErro($"Não foi possível encontrar um perfil para o usuário: {request.UserName}", NotificacaoTipo.ErroInterno);
                _logger.LogError($"Não foi possível encontrar um perfil para o usuário: {request.UserName}");
                return null;
            }

            return usuario.ToUsuarioResult();
        }
    }
}
