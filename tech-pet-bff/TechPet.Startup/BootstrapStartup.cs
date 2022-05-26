using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TechPet.Data;
using TechPet.Domain;
using TechPet.Identity;
using TechPet.Startup.Configurations;
using TechPet.UseCase;

namespace TechPet.Startup
{
    public static class BootstrapStartup
    {
        public static void AddBootstrapStartup(this WebApplicationBuilder builder)
        {
            LogConfiguration.AddSerilog(builder.Configuration);
            builder.Host.UseSerilog(Log.Logger);

            builder.Services.AddBootstrapData(builder.Configuration);
            builder.Services.AddBootstrapDomain();
            builder.Services.AddBootstrapUseCase();
            builder.Services.AddBootstrapIdentity(builder.Configuration);
            //builder.Services.AddScoped<ILogger, Log.Logger>();
        }
    }
}