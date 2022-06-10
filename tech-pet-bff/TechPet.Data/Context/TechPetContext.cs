using Microsoft.EntityFrameworkCore;
using TechPet.Data.Maps;
using TechPet.Data.Maps.Admin;
using TechPet.Domain.Entities.Usuarios;
using TechPet.Identity.Data;

namespace TechPet.Data.Context
{
    public class TechPetContext : IdentityContext
    {
        public TechPetContext(DbContextOptions<TechPetContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
        }
    }
}
