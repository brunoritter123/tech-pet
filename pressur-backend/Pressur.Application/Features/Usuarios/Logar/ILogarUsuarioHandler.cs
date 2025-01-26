using Pressur.Application.Abstractions;

namespace Pressur.Application.Features.Usuarios.Logar;

public interface ILogarUsuarioHandler : ICommandHandler<LogarUsuarioCommand, LogarUsuarioResponse>;