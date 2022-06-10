using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechPet.Data.Abstractions;
using TechPet.Domain.Entities.Empresas;

namespace TechPet.Data.Maps.Admin
{
    public class EmpresaMap : EntityMapConfigure<Empresa, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Empresa> builder)
        {
            builder.Property(x => x.Nome)
                .IsRequired();

            builder.Property(x => x.NomeFantasia)
                .IsRequired();

            builder.OwnsOne(x => x.Cnpj)
                .Property(x => x.Valor)
                .HasColumnName("Cnpj");
        }
    }
}
