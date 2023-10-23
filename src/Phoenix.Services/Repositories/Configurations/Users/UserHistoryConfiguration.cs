using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Users;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Users
{
   internal sealed class UserHistoryConfiguration : HistoryConfigurationBase<UserHistory>
   {
      public override void Configure(EntityTypeBuilder<UserHistory> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.UserId)
            .IsRequired();

         builder.Property(x => x.RoleId);

         builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

         builder.Property(x => x.Email)
            .HasMaxLength(50)
            .IsRequired();

         builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);

         builder.HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId);
      }
   }
}
