using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pressur.Data.Maps.Administracao;
using Pressur.Data.Maps.Cadastros;
using Pressur.Domain.Entities.Administracao;
using Pressur.Identity.Interfaces;

namespace Pressur.Data.Context
{
    public class PressurContext : DbContext
    {
        public const string NomePadraoCodigoEmpresa = "default";
        private readonly IConfiguration _configuration;
        private readonly string _codigoEmpresa;

        public PressurContext(DbContextOptions<PressurContext> options, IJwtService jwtService, IConfiguration configuration) : base(options)
        {
            _codigoEmpresa = jwtService.GetCodigoEmpresaUserLogado() ?? NomePadraoCodigoEmpresa;
            _configuration = configuration;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Usuario> Usuarios { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new UsuarioMap(_codigoEmpresa));
            modelBuilder.ApplyConfiguration(new EmpresaMap(_codigoEmpresa));

            modelBuilder.ApplyConfiguration(new CorDeVeiculoMap(_codigoEmpresa));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                _configuration.GetSection("ConnectionStrings:Mysql").Value,
                new MySqlServerVersion(new Version(8, 0, 29)));
        }
    }
}