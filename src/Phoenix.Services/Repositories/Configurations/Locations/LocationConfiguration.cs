using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Locations;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Locations
{
   internal sealed class LocationConfiguration : MetricConfigurationBase<Location>
   {
      public override void Configure(EntityTypeBuilder<Location> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.Name)
            .HasMaxLength(30)
            .IsRequired();

         builder.Property(x => x.IncludeReport)
            .IsRequired();
      }
   }
}
