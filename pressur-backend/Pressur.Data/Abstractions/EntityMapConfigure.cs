using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pressur.Domain.Abstractions.Entities;

namespace Pressur.Data.Abstractions
{
    public abstract class EntityMapConfigure<TEntity, TId> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity<TId>
        where TId : struct
    {
        private readonly string? _codigoEmpresa;
        
        public EntityMapConfigure(string codigoEmpresa)
        {
            _codigoEmpresa = codigoEmpresa;
        }

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(typeof(TEntity).Name);

            builder.HasKey(x => new {x.Id, x.CodigoEmpresa});

            builder.Property(x => x.CodigoEmpresa)
                .IsRequired();
            
            builder.Property(x => x.Id)
                .IsRequired();
            
            builder.HasQueryFilter(x => x.CodigoEmpresa == _codigoEmpresa);
            
            ConfigureEntity(builder);
        }

        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    }
}
