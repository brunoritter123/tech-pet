using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TechPet.Data.Maps;
using TechPet.Domain.Entities.Usuarios;
using TechPet.Identity.Interfaces;

namespace TechPet.Data.Context
{
    public class TechPetContext : DbContext
    {
        private readonly string _dataKey;
        private readonly IConfiguration _configuration;
        public TechPetContext(DbContextOptions<TechPetContext> options, IJwtService jwtService, IConfiguration configuration) : base(options)
        {
            _dataKey = jwtService.GetUserData() ?? "tech-pet";
            _configuration = configuration;
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStr = string.Format(_configuration.GetSection("ConnectionStrings:Mysql").Value, _dataKey);
            optionsBuilder.UseMySql(
                    connectionStr,
                    new MySqlServerVersion(new Version(8, 0, 29)));
        }
        public void UseDataBase(string nameDb)
        {
            var connectionStr = string.Format(_configuration.GetSection("ConnectionStrings:Mysql").Value, nameDb);
            Database.SetConnectionString(connectionStr);
        }

        public void CreateDataBase(string nameDb)
        {
            UseDataBase(nameDb);
            Database.Migrate();
        }

        public void DropDataBase()
        {
            Database.EnsureDeleted();
        }
    }
}
