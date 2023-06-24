using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Roles;

namespace Phoenix.Services.Repositories.Configurations.Roles
{
   internal sealed class RoleHistoryConfiguration : IEntityTypeConfiguration<RoleHistory>
   {
      public void Configure(EntityTypeBuilder<RoleHistory> builder)
      {
         builder.Property(x => x.RoleId)
            .IsRequired();

         builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

         builder.Property(x => x.Id)
            .IsRequired();

         builder.Property(x => x.IsActive)
            .IsRequired();

         builder.HasKey(x => x.Id)
            .IsClustered();

         builder.HasOne(x => x.Role)
            .WithMany(x => x.History)
            .HasForeignKey(x => x.RoleId);

         builder.HasOne(x => x.CreatedBy)
            .WithMany()
            .HasForeignKey(x => x.CreatedById);
      }
   }
}
