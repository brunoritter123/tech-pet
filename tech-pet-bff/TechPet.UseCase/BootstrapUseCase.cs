using Microsoft.Extensions.DependencyInjection;
using TechPet.UseCase.Services.Identity.NotifyIdentityErrors;
using TechPet.UseCase.UseCases.Empresas.IncluirEmpresa;
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
            service.AddScoped<IIncluirEmpresaUseCase, IncluirEmpresaUseCase>();
            service.AddScoped<INotifyIdentityErrorsService, NotifyIdentityErrorsService>();
            return service;
        }
    }
}
