using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Users;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Users
{
   internal sealed class UserConfiguration : MetricConfigurationBase<User>
   {
      public override void Configure(EntityTypeBuilder<User> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.RoleId)
            .IsRequired();

         builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

         builder.Property(x => x.Email)
            .HasMaxLength(50)
            .IsRequired();

         builder.Property(x => x.Password)
            .HasMaxLength(64)
            .IsFixedLength()
            .IsRequired();

         builder.HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId);
      }
   }
}
