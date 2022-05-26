using MediatR;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Entities.Usuarios.Repository;

namespace TechPet.Domain.Entities.Usuarios.Commands.RegistrarUsuario
{
    public class RegistrarUsuarioCommandHandler : IRequestHandler<RegistrarUsuarioCommand, UsuarioResult?>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly INotificacaoService _notificacaoService;
        public RegistrarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, INotificacaoService notificacaoService)
        {
            _usuarioRepository = usuarioRepository;
            _notificacaoService = notificacaoService;
        }
        public async Task<UsuarioResult?> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = request.ToUsuario();
            if (!usuario.Valido())
            {
                _notificacaoService.AddErro(usuario.GetErros());
                return default;
            }

            return (await _usuarioRepository.AddAsync(usuario))?.ToUsuarioResult();
        }
    }
}
