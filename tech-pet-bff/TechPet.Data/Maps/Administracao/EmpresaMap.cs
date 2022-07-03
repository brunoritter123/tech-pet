using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechPet.Data.Abstractions;
using TechPet.Domain.Entities.Empresas;
using TechPet.Domain.ValueObjects.CnpjObject;

namespace TechPet.Data.Maps.Administracao
{
    public class EmpresaMap : EntityMapConfigure<Empresa, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Empresa> builder)
        {
            builder.Property(x => x.Codigo)
                .IsRequired()
                .HasMaxLength(Empresa.TamanhoMaximoCodigo);

            builder
                .HasIndex(x => x.Codigo)
                .IsUnique();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(Empresa.TamanhoMaximoNome);

            builder.Property(x => x.NomeFantasia)
                .IsRequired()
                .HasMaxLength(Empresa.TamanhoMaximoNomeFantasia);

            builder.OwnsOne(x => x.Cnpj)
                .Property(x => x.Valor)
                .HasColumnName("Cnpj")
                .IsRequired()
                .HasMaxLength(Cnpj.TamanhoCnpj);
        }
    }
}
