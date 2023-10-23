using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Roles;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Roles
{
   internal sealed class RoleConfiguration : MetricConfigurationBase<Role>
   {
      public override void Configure(EntityTypeBuilder<Role> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

         builder.Property(x => x.IsAdmin)
            .IsRequired();
      }
   }
}
