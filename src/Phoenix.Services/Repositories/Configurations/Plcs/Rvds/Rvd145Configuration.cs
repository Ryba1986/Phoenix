using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Plcs.Rvds;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Plcs.Rvds
{
   internal sealed class Rvd145Configuration : PlcConfigurationBase<Rvd145>
   {
      public override void Configure(EntityTypeBuilder<Rvd145> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.OutsideTemp)
            .IsRequired();

         builder.Property(x => x.ChHighInletPresure)
            .IsRequired();

         builder.Property(x => x.Alarm)
            .IsRequired();

         builder.Property(x => x.Ch1HighOutletTemp)
            .IsRequired();

         builder.Property(x => x.Ch1LowInletTemp)
            .IsRequired();

         builder.Property(x => x.Ch1LowOutletPresure)
            .IsRequired();

         builder.Property(x => x.Ch1HeatCurveTemp)
            .IsRequired();

         builder.Property(x => x.Ch1PumpStatus)
            .IsRequired();

         builder.Property(x => x.Ch1Status)
            .IsRequired();

         builder.Property(x => x.DhwTemp)
            .IsRequired();

         builder.Property(x => x.DhwTempSet)
            .IsRequired();

         builder.Property(x => x.DhwCirculationTemp)
            .IsRequired();

         builder.Property(x => x.DhwPumpStatus)
            .IsRequired();

         builder.Property(x => x.DhwStatus)
            .IsRequired();
      }
   }
}
