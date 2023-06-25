using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Devices;

namespace Phoenix.Services.Repositories.Configurations.Devices
{
   internal sealed class DeviceConfiguration : IEntityTypeConfiguration<Device>
   {
      public void Configure(EntityTypeBuilder<Device> builder)
      {
         builder.Property(x => x.LocationId)
            .IsRequired();

         builder.Property(x => x.Name)
            .HasMaxLength(30)
            .IsRequired();

         builder.Property(x => x.DeviceType)
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

         builder.Property(x => x.IncludeReport)
            .IsRequired();

         builder.Property(x => x.Id)
            .IsRequired();

         builder.Property(x => x.IsActive)
            .IsRequired();

         builder.Property(x => x.Version)
            .IsRequired()
            .IsRowVersion();

         builder.HasKey(x => x.Id)
            .IsClustered();

         builder.HasOne(x => x.Location)
            .WithMany()
            .HasForeignKey(x => x.LocationId);
      }
   }
}
