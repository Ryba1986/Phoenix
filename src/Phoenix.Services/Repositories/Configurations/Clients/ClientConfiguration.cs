using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Clients;

namespace Phoenix.Services.Repositories.Configurations.Clients
{
   internal sealed class ClientConfiguration : IEntityTypeConfiguration<Client>
   {
      public void Configure(EntityTypeBuilder<Client> builder)
      {
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

         builder.Property(x => x.Id)
            .IsRequired();

         builder.Property(x => x.IsActive)
            .IsRequired();

         builder.Property(x => x.Version)
            .IsRequired();

         builder.HasKey(x => x.Id);

         builder.HasOne(x => x.Location)
            .WithMany()
            .HasForeignKey(x => x.LocationId);
      }
   }
}
