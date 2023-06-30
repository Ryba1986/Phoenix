using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Plcs.Rvds;

namespace Phoenix.Services.Repositories.Configurations.Plcs.Rvds
{
   internal sealed class Rvd145Configuration : IEntityTypeConfiguration<Rvd145>
   {
      public void Configure(EntityTypeBuilder<Rvd145> builder)
      {
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
