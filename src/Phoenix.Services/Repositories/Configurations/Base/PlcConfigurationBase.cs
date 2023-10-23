using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Base;

namespace Phoenix.Services.Repositories.Configurations.Base
{
   internal abstract class PlcConfigurationBase<T> : IEntityTypeConfiguration<T> where T : PlcBase
   {
      public virtual void Configure(EntityTypeBuilder<T> builder)
      {
         builder.Property(x => x.Date)
            .HasPrecision(0)
            .IsRequired();

         builder.Property(x => x.DeviceId)
            .IsRequired();

         builder.HasKey(x => new { x.Date, x.DeviceId });

         builder.HasOne(x => x.Device)
            .WithMany()
            .HasForeignKey(x => x.DeviceId);
      }
   }
}
