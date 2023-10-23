using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Base;

namespace Phoenix.Services.Repositories.Configurations.Base
{
   internal abstract class EntityConfigurationBase<T> : IEntityTypeConfiguration<T> where T : EntityBase
   {
      public virtual void Configure(EntityTypeBuilder<T> builder)
      {
         builder.Property(x => x.Id)
            .IsRequired();

         builder.HasKey(x => x.Id);
      }
   }
}
