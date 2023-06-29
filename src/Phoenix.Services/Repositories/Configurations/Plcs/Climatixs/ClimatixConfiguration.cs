using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Plcs.Climatixs;

namespace Phoenix.Services.Repositories.Configurations.Plcs.Climatixs
{
   internal sealed class ClimatixConfiguration : IEntityTypeConfiguration<Climatix>
   {
      public void Configure(EntityTypeBuilder<Climatix> builder)
      {
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

         builder.Property(x => x.DeviceId)
            .IsRequired();

         builder.Property(x => x.Date)
            .IsRequired();

         builder.HasKey(x => new { x.Date, x.DeviceId })
            .IsClustered();

         builder.HasOne(x => x.Device)
            .WithMany()
            .HasForeignKey(x => x.DeviceId);
      }
   }
}
