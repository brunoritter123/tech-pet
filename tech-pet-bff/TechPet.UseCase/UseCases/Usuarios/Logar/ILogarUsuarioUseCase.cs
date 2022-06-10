using TechPet.Domain.Entities.Usuarios;
using TechPet.UseCase.Abstractions;
using TechPet.UseCase.Usuarios.Logar;

namespace TechPet.UseCase.UseCases.Usuarios.Logar
{
    public interface ILogarUsuarioUseCase : IUseCase<LogarUsuarioRequest, LogarUsuarioResponse?>
    {
    }
}
