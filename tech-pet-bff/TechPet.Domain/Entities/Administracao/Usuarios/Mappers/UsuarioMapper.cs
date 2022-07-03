using TechPet.Domain.Entities.Usuarios.Commands.RegistrarUsuario;

namespace TechPet.Domain.Entities.Usuarios.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioResult ToUsuarioResult(this Usuario usuario)
            => new UsuarioResult(usuario.Login, usuario.Nome, usuario.Email);

        public static Usuario ToUsuario(this RegistrarUsuarioCommand command)
            => new Usuario(command.Login, command.Nome, command.Email);
    }
}
