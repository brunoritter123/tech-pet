using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechPet.Domain.Abstractions;
using TechPet.Domain.Abstractions.Entities;

namespace TechPet.Data.Abstractions
{
    public abstract class EntityMapConfigure<TEntity, TId> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity<TId>
        where TId : struct
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(typeof(TEntity).Name);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            ConfigureEntity(builder);
        }

        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    }
}
