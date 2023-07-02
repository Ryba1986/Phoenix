using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Plcs.Meters;

namespace Phoenix.Services.Repositories.Configurations.Plcs.Meters
{
   internal sealed class KamstrupConfiguration : IEntityTypeConfiguration<Kamstrup>
   {
      public void Configure(EntityTypeBuilder<Kamstrup> builder)
      {
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

         builder.Property(x => x.Date)
            .IsRequired();

         builder.Property(x => x.DeviceId)
            .IsRequired();

         builder.HasKey(x => new { x.Date, x.DeviceId })
            .IsClustered();

         builder.HasOne(x => x.Device)
            .WithMany()
            .HasForeignKey(x => x.DeviceId);
      }
   }
}
