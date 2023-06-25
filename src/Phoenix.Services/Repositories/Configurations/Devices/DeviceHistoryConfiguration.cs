using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Devices;

namespace Phoenix.Services.Repositories.Configurations.Devices
{
   internal sealed class DeviceHistoryConfiguration : IEntityTypeConfiguration<DeviceHistory>
   {
      public void Configure(EntityTypeBuilder<DeviceHistory> builder)
      {
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

         builder.Property(x => x.IncludeReport)
            .IsRequired();

         builder.Property(x => x.Id)
            .IsRequired();

         builder.Property(x => x.IsActive)
           .IsRequired();

         builder.Property(x => x.CreatedById)
            .IsRequired();

         builder.Property(x => x.CreateDate)
            .IsRequired();

         builder.HasKey(x => x.Id)
            .IsClustered();

         builder.HasOne(x => x.Device)
            .WithMany(x => x.History)
            .HasForeignKey(x => x.DeviceId);

         builder.HasOne(x => x.Location)
            .WithMany()
            .HasForeignKey(x => x.LocationId);

         builder.HasOne(x => x.CreatedBy)
            .WithMany()
            .HasForeignKey(x => x.CreatedById);
      }
   }
}
