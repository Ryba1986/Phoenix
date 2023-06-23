using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Roles;

namespace Phoenix.Services.Repositories.Configurations.Roles
{
   internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
   {
      public void Configure(EntityTypeBuilder<Role> builder)
      {
         builder.Property(x => x.Name)
            .HasMaxLength(50)
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
      }
   }
}
