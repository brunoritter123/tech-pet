using Pressur.Application.Abstractions;

namespace Pressur.Application.Features.Usuarios.Registrar;

public interface IRegistrarUsuarioHandler : ICommandHandler<RegistrarUsuarioCommand, RegistrarUsuarioResponse>;
