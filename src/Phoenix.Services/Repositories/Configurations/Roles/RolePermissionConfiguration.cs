using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Roles;

namespace Phoenix.Services.Repositories.Configurations.Roles
{
   internal sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
   {
      public void Configure(EntityTypeBuilder<RolePermission> builder)
      {
         builder.Property(x => x.RoleId)
            .IsRequired();

         builder.Property(x => x.Permission)
            .IsRequired();

         builder.Property(x => x.AccessLevel)
            .IsRequired();

         builder.Property(x => x.Id)
            .IsRequired();

         builder.Property(x => x.IsActive)
            .IsRequired();

         builder.Property(x => x.Version)
            .IsRequired()
            .IsRowVersion();

         builder.HasKey(x => x.Id)
            .IsClustered();

         builder.HasOne<Role>()
            .WithMany()
            .HasForeignKey(x => x.RoleId);
      }
   }
}
