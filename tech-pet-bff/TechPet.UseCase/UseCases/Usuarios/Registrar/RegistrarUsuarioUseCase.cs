using MediatR;
using Microsoft.Extensions.Logging;
using TechPet.Data.Abstractions;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Entities.Usuarios;
using TechPet.Domain.Entities.Usuarios.Commands.RegistrarUsuario;
using TechPet.Identity.Entities;
using TechPet.Identity.Interfaces;
using TechPet.UseCase.Abstractions;
using TechPet.Application.Extensions.Identity.NotifyIdentityErrors;

namespace TechPet.UseCase.UseCases.Usuarios.Registrar
{
    public class RegistrarUsuarioUseCase : UseCaseCommand<RegistrarUsuarioCommand, UsuarioResult?>, IRegistrarUsuarioUseCase
    {
        private readonly IIdentityService _identityService;

        public RegistrarUsuarioUseCase(INotificacaoService notificacaoService, IMediator mediator, IUnitOfWork unitOfWork, ILogger<RegistrarUsuarioUseCase> logger, IIdentityService identityService) : base(notificacaoService, mediator, unitOfWork, logger)
        {
            _identityService = identityService;
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
                _notificacaoService.AddNotificationsIdentity(result.Erros, userIdentity, _logger);
                return null;
            }

            return novoUsuario;
        }
    }
}
