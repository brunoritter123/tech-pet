using Microsoft.Extensions.DependencyInjection;
using TechPet.IntegrationTests.UseCase;

namespace TechPet.UseCase
{
    public static class BootstrapIntegrationTests
    {
        public static IServiceCollection AddBootstrapIntegrationTests(this IServiceCollection service)
        {
            service.AddScoped<IIntegrationTestsUseCase, IntegrationTestsUseCase>();
            return service;
        }
    }
}
