using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Base;
using Phoenix.Services.Repositories.Converters;

namespace Phoenix.Services.Repositories.Configurations.Base
{
   internal abstract class HistoryConfigurationBase<T> : EntityConfigurationBase<T> where T : HistoryBase
   {
      public override void Configure(EntityTypeBuilder<T> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.CreatedById)
            .IsRequired();

         builder.Property(x => x.IsActive)
            .IsRequired();

         builder.Property(x => x.CreateDate)
            .HasPrecision(0)
            .IsRequired()
            .HasConversion<DateTimeConverter>();

         builder.HasOne(x => x.CreatedBy)
            .WithMany()
            .HasForeignKey(x => x.CreatedById);
      }
   }
}
