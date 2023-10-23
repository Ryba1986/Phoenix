using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Plcs.Meters;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Plcs.Meters
{
   internal sealed class KamstrupConfiguration : PlcConfigurationBase<Kamstrup>
   {
      public override void Configure(EntityTypeBuilder<Kamstrup> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.InletTemp)
            .IsRequired();

         builder.Property(x => x.OutletTemp)
            .IsRequired();

         builder.Property(x => x.Power)
            .IsRequired();

         builder.Property(x => x.Volume)
            .IsRequired();

         builder.Property(x => x.VolumeSummary)
            .IsRequired();

         builder.Property(x => x.EnergySummary)
            .IsRequired();

         builder.Property(x => x.HourCount)
            .IsRequired();

         builder.Property(x => x.ErrorCode)
            .IsRequired();
      }
   }
}
