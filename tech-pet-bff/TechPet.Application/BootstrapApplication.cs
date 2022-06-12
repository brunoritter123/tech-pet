using Microsoft.Extensions.DependencyInjection;
using TechPet.Application.Commands.CriarNovoBancoDeDados;
using TechPet.Application.Commands.IncluirUsers;

namespace TechPet.Application
{
    public static class BootstrapApplication
    {
        public static IServiceCollection AddBootstrapApplication(this IServiceCollection service)
        {
            service.AddTransient<IIncluirUsersCommand, IncluirUsersCommand>();
            service.AddTransient<ICriarNovoBancoDeDadosCommand, CriarNovoBancoDeDadosCommand>();
            return service;
        }
    }
}
