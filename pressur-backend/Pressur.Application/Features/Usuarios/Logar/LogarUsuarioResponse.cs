namespace Pressur.Application.Features.Usuarios.Logar;

public class LogarUsuarioResponse
{
    public required string Token { get; init; }
    public required Usuario User { get; init; }

    public class Usuario
    {
        public required string Login { get; init; }
        public required string Nome { get; init; }
        public required string Email { get; init; }
    }
}
