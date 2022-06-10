using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechPet.Data.Abstractions;
using TechPet.Data.Context;
using TechPet.Data.Repositories;
using TechPet.Domain.Entities.Empresas.Repository;
using TechPet.Domain.Entities.Usuarios.Repository;

namespace TechPet.Data
{
    public static class BootstrapData
    {
        public static IServiceCollection AddBootstrapData(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddDbContext<TechPetContext>(options =>
                options.UseMySql(
                    configuration.GetSection("ConnectionStrings:Mysql").Value,
                    new MySqlServerVersion(new Version(8,0,29))));

            service.AddScoped<DbContext, TechPetContext>();
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();
            service.AddScoped<IEmpresaRepository, EmpresaRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}
