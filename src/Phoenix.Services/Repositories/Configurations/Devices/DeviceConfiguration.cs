using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Devices;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Devices
{
   internal sealed class DeviceConfiguration : MetricConfigurationBase<Device>
   {
      public override void Configure(EntityTypeBuilder<Device> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.LocationId)
            .IsRequired();

         builder.Property(x => x.Name)
            .HasMaxLength(30)
            .IsRequired();

         builder.Property(x => x.PlcType)
            .IsRequired();

         builder.Property(x => x.ModbusId)
            .IsRequired();

         builder.Property(x => x.BoundRate)
            .IsRequired();

         builder.Property(x => x.DataBits)
            .IsRequired();

         builder.Property(x => x.Parity)
            .IsRequired();

         builder.Property(x => x.StopBits)
            .IsRequired();

         builder.Property(x => x.SerialNumber)
         .HasMaxLength(30)
         .IsRequired();

         builder.Property(x => x.ReportSequence)
            .IsRequired();

         builder.Property(x => x.IncludeReport)
            .IsRequired();

         builder.HasOne(x => x.Location)
            .WithMany()
            .HasForeignKey(x => x.LocationId);
      }
   }
}
