using TechPet.Domain.Entities.Usuarios;
using TechPet.UseCase.Abstractions;
using TechPet.UseCase.Requests;

namespace TechPet.UseCase.UseCases.Usuarios.Logar
{
    public interface ILogarUsuarioUseCase : IUseCase<UsuarioLoginRequest, UsuarioResult?>
    {
    }
}
