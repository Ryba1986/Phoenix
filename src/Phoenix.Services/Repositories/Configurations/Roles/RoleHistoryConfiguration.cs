using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Roles;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Roles
{
   internal sealed class RoleHistoryConfiguration : HistoryConfigurationBase<RoleHistory>
   {
      public override void Configure(EntityTypeBuilder<RoleHistory> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.RoleId)
            .IsRequired();

         builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

         builder.Property(x => x.IsAdmin)
            .IsRequired();

         builder.HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId);
      }
   }
}
