using Microsoft.AspNetCore.Builder;
using Microsoft.FeatureManagement;
using Serilog;
using TechPet.Data;
using TechPet.Domain;
using TechPet.Identity;
using TechPet.Startup.Configurations;
using TechPet.UseCase;
using TechPet.Application;

namespace TechPet.Startup
{
    public static class BootstrapStartup
    {
        public static void AddBootstrapStartup(this WebApplicationBuilder builder)
        {
            AddFeatureManagement(builder);
            AddSerilog(builder);
            AddBootstrapTechPet(builder);
        }

        private static void AddFeatureManagement(WebApplicationBuilder builder)
        {
            builder.Services.AddFeatureManagement();
        }

        private static void AddSerilog(WebApplicationBuilder builder)
        {
            LogConfiguration.AddSerilog(builder.Configuration);
            builder.Host.UseSerilog(Log.Logger);
        }

        private static void AddBootstrapTechPet(WebApplicationBuilder builder)
        {
            builder.Services.AddBootstrapData(builder.Configuration);
            builder.Services.AddBootstrapDomain();
            builder.Services.AddBootstrapApplication();
            builder.Services.AddBootstrapUseCase();
            builder.Services.AddBootstrapIdentity(builder.Configuration);
            builder.Services.AddBootstrapIntegrationTests();
        }
    }
}