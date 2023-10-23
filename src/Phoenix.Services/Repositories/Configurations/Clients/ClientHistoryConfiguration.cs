using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Clients;
using Phoenix.Services.Repositories.Configurations.Base;

namespace Phoenix.Services.Repositories.Configurations.Clients
{
   internal sealed class ClientHistoryConfiguration : HistoryConfigurationBase<ClientHistory>
   {
      public override void Configure(EntityTypeBuilder<ClientHistory> builder)
      {
         base.Configure(builder);

         builder.Property(x => x.ClientId)
            .IsRequired();

         builder.Property(x => x.LocationId);

         builder.Property(x => x.MacAddress)
            .HasMaxLength(12)
            .IsRequired();

         builder.Property(x => x.Hostname)
            .HasMaxLength(66)
            .IsRequired();

         builder.Property(x => x.ClientVersion)
            .HasMaxLength(20)
            .IsRequired();

         builder.HasOne(x => x.Client)
            .WithMany()
            .HasForeignKey(x => x.ClientId);

         builder.HasOne(x => x.Location)
            .WithMany()
            .HasForeignKey(x => x.LocationId);
      }
   }
}
