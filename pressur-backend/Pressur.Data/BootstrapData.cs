using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pressur.Data.Abstractions;
using Pressur.Data.Context;
using Pressur.Data.Repositories;
using Pressur.Data.Repositories.Administracao;
using Pressur.Data.Repositories.Cadastros;
using Pressur.Domain.Abstractions.Repository;

namespace Pressur.Data
{
    public static class BootstrapData
    {
        public static IServiceCollection AddBootstrapData(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddDbContext<PressurContext>();

            service.AddScoped<DbContext, PressurContext>();
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();
            service.AddScoped<IEmpresaRepository, EmpresaRepository>();
            service.AddScoped<ICorDeVeiculoRepository, CorDeVeiculoRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}
