using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechPet.Data.Abstractions;
using TechPet.Data.Context;
using TechPet.Data.Repositories;
using TechPet.Domain.Entities.Usuarios.Repository;

namespace TechPet.Data
{
    public static class BootstrapData
    {
        public static IServiceCollection AddBootstrapData(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddDbContext<TechPetContext>(options =>
                options.UseNpgsql(configuration.GetSection("ConnectionStrings:Npgsql").Value));

            service.AddScoped<DbContext, TechPetContext>();
            service.AddScoped<IDbReadContext, TechPetReadContext>();
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}
