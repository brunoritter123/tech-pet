using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechPet.Data.Abstractions;
using TechPet.Data.Seeds;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo;

namespace TechPet.Data.Maps.Cadastros
{
    public class CorDeVeiculoMap : EntityMapConfigure<CorDeVeiculo, short>
    {
        public override void ConfigureEntity(EntityTypeBuilder<CorDeVeiculo> builder)
        {
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(CorDeVeiculo.TamanhoMaximoNome);

            builder.HasData(CorDeVeiculoSeed.Gerar());
        }
    }
}