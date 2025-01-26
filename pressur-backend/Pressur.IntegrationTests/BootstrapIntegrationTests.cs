using Microsoft.Extensions.DependencyInjection;
using Pressur.IntegrationTests.UseCase;

namespace Pressur.Application
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
