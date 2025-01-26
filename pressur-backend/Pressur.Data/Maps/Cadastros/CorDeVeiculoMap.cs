using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pressur.Data.Abstractions;
using Pressur.Data.Seeds;
using Pressur.Domain.Entities.Cadastros;

namespace Pressur.Data.Maps.Cadastros
{
    public class CorDeVeiculoMap : EntityMapConfigure<CorDeVeiculo, short>
    {
        public CorDeVeiculoMap(string codigoEmpresa) : base(codigoEmpresa) { }

        public override void ConfigureEntity(EntityTypeBuilder<CorDeVeiculo> builder)
        {
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(CorDeVeiculo.TamanhoMaximoNome);

            builder.HasData(CorDeVeiculoSeed.Gerar());
        }
    }
}