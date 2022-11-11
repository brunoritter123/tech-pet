using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechPet.Identity.Entities;

namespace TechPet.Identity.Data.Maps
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable(nameof(Empresa));

            builder.HasKey(x => x.Codigo);

            //builder.HasMany(cr => cr.Users)
            //    .WithOne(x => x.CodigoEmpresa);
        }
    }
}
