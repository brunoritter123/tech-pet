
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pressur.Data.Abstractions;
using Pressur.Domain.Entities.Administracao;
using Pressur.Domain.ValueObjects.CnpjObject;

namespace Pressur.Data.Maps.Administracao
{
    public class EmpresaMap : EntityMapConfigure<Empresa, Guid>
    {
        public EmpresaMap(string codigoEmpresa) : base(codigoEmpresa) { }

        public override void ConfigureEntity(EntityTypeBuilder<Empresa> builder)
        {
            builder.Property(x => x.CodigoEmpresa)
                .HasMaxLength(Empresa.TamanhoMaximoCodigo);

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
