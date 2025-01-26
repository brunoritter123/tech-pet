using Pressur.Domain.Entities.Administracao;

namespace Pressur.Application.Features.Usuarios.Registrar;

public class RegistrarUsuarioResponse
{
    public required string Login { get; init; }
    public required string Nome { get; init; }
    public required string Email { get; init; }

    public static implicit operator RegistrarUsuarioResponse(Usuario entity)
    {
        return new RegistrarUsuarioResponse()
        {
            Login = entity.Login,
            Nome = entity.Nome,
            Email = entity.Email
        };
    }
}