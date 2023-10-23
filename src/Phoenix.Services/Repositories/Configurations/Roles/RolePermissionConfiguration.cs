using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Roles;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Roles
{
   internal sealed class RolePermissionConfiguration : MetricConfigurationBase<RolePermission>
   {
      public override void Configure(EntityTypeBuilder<RolePermission> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.RoleId)
            .IsRequired();

         builder.Property(x => x.Permission)
            .IsRequired();

         builder.Property(x => x.AccessLevel)
            .IsRequired();

         builder.HasOne(x => x.Role)
            .WithMany(x => x.Permissions)
            .HasForeignKey(x => x.RoleId);
      }
   }
}
