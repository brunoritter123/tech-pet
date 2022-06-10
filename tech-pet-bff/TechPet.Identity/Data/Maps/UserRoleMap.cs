using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechPet.Identity.Entities;

namespace TechPet.Identity.Data.Maps
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(nameof(UserRole));

            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.HasOne(cr => cr.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(cr => cr.RoleId)
                .IsRequired();

            builder.HasOne(cr => cr.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(cr => cr.RoleId)
                .IsRequired();

        }
    }
}
