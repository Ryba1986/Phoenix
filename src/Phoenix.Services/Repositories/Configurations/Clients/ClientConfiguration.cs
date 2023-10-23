using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Clients;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Clients
{
   internal sealed class ClientConfiguration : MetricConfigurationBase<Client>
   {
      public override void Configure(EntityTypeBuilder<Client> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.LocationId)
            .IsRequired();

         builder.Property(x => x.MacAddress)
            .HasMaxLength(12)
            .IsFixedLength()
            .IsRequired();

         builder.Property(x => x.Hostname)
            .HasMaxLength(66)
            .IsRequired();

         builder.Property(x => x.ClientVersion)
            .HasMaxLength(20)
            .IsRequired();

         builder.HasOne(x => x.Location)
            .WithMany()
            .HasForeignKey(x => x.LocationId);
      }
   }
}
