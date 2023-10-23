using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Plcs.Climatixs;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Plcs.Climatixs
{
   internal sealed class ClimatixConfiguration : PlcConfigurationBase<Climatix>
   {
      public override void Configure(EntityTypeBuilder<Climatix> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.OutsideTemp)
            .IsRequired();

         builder.Property(x => x.ChHighInletPresure)
            .IsRequired();

         builder.Property(x => x.ChHighOutletPresure)
            .IsRequired();

         builder.Property(x => x.Alarm)
            .IsRequired();

         builder.Property(x => x.Ch1LowInletTemp)
            .IsRequired();

         builder.Property(x => x.Ch1LowOutletTemp)
            .IsRequired();

         builder.Property(x => x.Ch1LowOutletPresure)
            .IsRequired();

         builder.Property(x => x.Ch1HeatCurveTemp)
            .IsRequired();

         builder.Property(x => x.Ch1PumpAlarm)
            .IsRequired();

         builder.Property(x => x.Ch1PumpStatus)
            .IsRequired();

         builder.Property(x => x.Ch1ValvePosition)
            .IsRequired();

         builder.Property(x => x.Ch1Status)
            .IsRequired();

         builder.Property(x => x.Ch2LowInletTemp)
            .IsRequired();

         builder.Property(x => x.Ch2LowOutletTemp)
            .IsRequired();

         builder.Property(x => x.Ch2LowOutletPresure)
            .IsRequired();

         builder.Property(x => x.Ch2HeatCurveTemp)
            .IsRequired();

         builder.Property(x => x.Ch2PumpAlarm)
            .IsRequired();

         builder.Property(x => x.Ch2PumpStatus)
            .IsRequired();

         builder.Property(x => x.Ch2ValvePosition)
            .IsRequired();

         builder.Property(x => x.Ch2Status)
            .IsRequired();

         builder.Property(x => x.DhwTemp)
            .IsRequired();

         builder.Property(x => x.DhwTempSet)
            .IsRequired();

         builder.Property(x => x.DhwPumpAlarm)
            .IsRequired();

         builder.Property(x => x.DhwPumpStatus)
            .IsRequired();

         builder.Property(x => x.DhwValvePosition)
            .IsRequired();

         builder.Property(x => x.DhwStatus)
            .IsRequired();
      }
   }
}
