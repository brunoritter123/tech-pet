using Microsoft.Extensions.DependencyInjection;
using TechPet.UseCase.UseCases.Usuarios.Logar;
using TechPet.UseCase.UseCases.Usuarios.Registrar;

namespace TechPet.UseCase
{
    public static class BootstrapUseCase
    {
        public static IServiceCollection AddBootstrapUseCase(this IServiceCollection service)
        {
            service.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>();
            service.AddScoped<ILogarUsuarioUseCase, LogarUsuarioUseCase>();
            return service;
        }
    }
}
