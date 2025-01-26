using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pressur.Data.Abstractions;
using Pressur.Domain.Entities.Administracao;

namespace Pressur.Data.Maps.Administracao
{
    public class UsuarioMap : EntityMapConfigure<Usuario, Guid>
    {
        public UsuarioMap(string codigoEmpresa) : base(codigoEmpresa) { }

        public override void ConfigureEntity(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Login);

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
