using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Devices;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Devices
{
   internal sealed class DeviceHistoryConfiguration : HistoryConfigurationBase<DeviceHistory>
   {
      public override void Configure(EntityTypeBuilder<DeviceHistory> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.DeviceId)
            .IsRequired();

         builder.Property(x => x.LocationId);

         builder.Property(x => x.Name)
            .HasMaxLength(30)
            .IsRequired();

         builder.Property(x => x.DeviceType);

         builder.Property(x => x.PlcType);

         builder.Property(x => x.ModbusId);

         builder.Property(x => x.BoundRate);

         builder.Property(x => x.DataBits);

         builder.Property(x => x.Parity);

         builder.Property(x => x.StopBits);

         builder.Property(x => x.SerialNumber)
            .HasMaxLength(20)
            .IsRequired();

         builder.Property(x => x.ReportSequence);

         builder.Property(x => x.IncludeReport)
            .IsRequired();

         builder.HasOne(x => x.Device)
            .WithMany()
            .HasForeignKey(x => x.DeviceId);

         builder.HasOne(x => x.Location)
            .WithMany()
            .HasForeignKey(x => x.LocationId);
      }
   }
}
