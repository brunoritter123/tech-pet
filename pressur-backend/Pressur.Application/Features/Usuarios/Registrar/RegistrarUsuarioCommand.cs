using Pressur.Domain.Entities.Administracao;

namespace Pressur.Application.Features.Usuarios.Registrar;

public record RegistrarUsuarioCommand(
    string Login,
    string Nome,
    string Email,
    string Senha)
{
    public static implicit operator Usuario(RegistrarUsuarioCommand command)
    {
        return new Usuario(
            login: command.Login,
            nome: command.Nome,
            email: command.Email
        );
    }
}
