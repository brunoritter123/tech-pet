using MediatR;
using Microsoft.Extensions.Logging;
using TechPet.Data.Abstractions;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Entities.Usuarios;
using TechPet.Domain.Entities.Usuarios.Commands.RegistrarUsuario;
using TechPet.Identity.Entities;
using TechPet.Identity.Interfaces;
using TechPet.UseCase.Abstractions;

namespace TechPet.UseCase.UseCases.Usuarios
{
    public class RegistrarUsuarioUseCase : UseCaseCommand<RegistrarUsuarioCommand, UsuarioResult?>, IRegistrarUsuarioUseCase
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger<RegistrarUsuarioUseCase> _logger;

        public RegistrarUsuarioUseCase(INotificacaoService notificacaoService, IMediator mediator, IUnitOfWork unitOfWork, ILogger<RegistrarUsuarioUseCase> logger, IIdentityService identityService) : base(notificacaoService, mediator, unitOfWork, logger)
        {
            _identityService = identityService;
            _logger = logger;
        }

        protected async override Task<UsuarioResult?> AoExecutarAsync(RegistrarUsuarioCommand request)
        {
            var novoUsuario = await _mediator.Send(request);
            if (_notificacaoService.ExisteNotificacao()) return default;

            var userIdentity = new User()
            {
                Email = request.Email,
                Nome = request.Nome,
                UserName = request.Login
            };

            var result = await _identityService.CriarUsuarioAsync(userIdentity, request.Senha);
            if (!result.Sucesso)
            {
                _notificacaoService.AddErro("Não foi possível registrar usuário", NotificacaoTipo.ErroInterno);
                result.Erros.ToList().ForEach(x => _logger.LogError(x.Menssagem));
                return null;
            }

            return novoUsuario;
        }
    }
}
