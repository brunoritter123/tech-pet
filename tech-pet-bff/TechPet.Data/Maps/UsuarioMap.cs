using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechPet.Domain.Entities.Usuarios;

namespace TechPet.Data.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Login)
                .IsUnique();

            builder
                .Property(x => x.Login)
                .IsRequired();

            builder
                .Property(x => x.Nome)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .IsRequired();
        }
    }
}
