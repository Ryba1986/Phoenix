using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Base;

namespace Phoenix.Services.Repositories.Configurations.Base
{
   internal abstract class MetricConfigurationBase<T> : EntityConfigurationBase<T> where T : MetricBase
   {
      public override void Configure(EntityTypeBuilder<T> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.IsActive)
            .IsRequired();

         builder.Property(x => x.Version)
            .IsRequired();
      }
   }
}
