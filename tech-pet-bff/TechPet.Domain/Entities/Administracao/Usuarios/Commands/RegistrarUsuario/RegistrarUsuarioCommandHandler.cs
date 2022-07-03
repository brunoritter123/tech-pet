using MediatR;
using TechPet.Domain.Abstractions.Commands;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Entities.Usuarios.Mappers;
using TechPet.Domain.Entities.Usuarios.Repository;

namespace TechPet.Domain.Entities.Usuarios.Commands.RegistrarUsuario
{
    public class RegistrarUsuarioCommandHandler : CommandHandlerInsert<RegistrarUsuarioCommand, UsuarioResult?, Usuario, Guid>
    {
        public RegistrarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, INotificacaoService notificacaoService)
            : base(notificacaoService, usuarioRepository)
        {
        }

        protected override Usuario CommandToEntity(RegistrarUsuarioCommand command)
        {
            return command.ToUsuario();
        }

        protected override UsuarioResult? ResultRepositoryToResponse(Usuario? entity)
        {
            return entity?.ToUsuarioResult();
        }

        protected override bool ValidCommand(RegistrarUsuarioCommand command)
        {
            return true;
        }
    }
}
