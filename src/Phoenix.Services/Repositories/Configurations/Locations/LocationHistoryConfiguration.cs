using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Locations;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Locations
{
   internal sealed class LocationHistoryConfiguration : HistoryConfigurationBase<LocationHistory>
   {
      public override void Configure(EntityTypeBuilder<LocationHistory> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.LocationId)
            .IsRequired();

         builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

         builder.Property(x => x.IncludeReport)
            .IsRequired();

         builder.HasOne(x => x.Location)
            .WithMany()
            .HasForeignKey(x => x.LocationId);
      }
   }
}
