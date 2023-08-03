using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Locations;

namespace Phoenix.Services.Repositories.Configurations.Locations
{
   internal sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
   {
      public void Configure(EntityTypeBuilder<Location> builder)
      {
         builder.Property(x => x.Name)
            .HasMaxLength(30)
            .IsRequired();

         builder.Property(x => x.IncludeReport)
            .IsRequired();

         builder.Property(x => x.Id)
            .IsRequired();

         builder.Property(x => x.IsActive)
            .IsRequired();

         builder.Property(x => x.Version)
            .IsRequired();

         builder.HasKey(x => x.Id);
      }
   }
}
