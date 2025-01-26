namespace Pressur.Application.Features.Usuarios.Logar;

public record LogarUsuarioCommand(
    string Login,
    string Password,
    bool RememberUser
);

