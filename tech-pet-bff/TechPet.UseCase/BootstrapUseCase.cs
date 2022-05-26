using Microsoft.Extensions.DependencyInjection;
using TechPet.UseCase.UseCases.Usuarios;

namespace TechPet.UseCase
{
    public static class BootstrapUseCase
    {
        public static IServiceCollection AddBootstrapUseCase(this IServiceCollection service)
        {
            service.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>();
            return service;
        }
    }
}
