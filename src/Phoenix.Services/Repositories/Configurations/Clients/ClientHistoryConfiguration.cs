using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Entities.Clients;

namespace Phoenix.Services.Repositories.Configurations.Clients
{
   internal sealed class ClientHistoryConfiguration : IEntityTypeConfiguration<ClientHistory>
   {
      public void Configure(EntityTypeBuilder<ClientHistory> builder)
      {
         builder.Property(x => x.ClientId)
            .IsRequired();

         builder.Property(x => x.LocationId);

         builder.Property(x => x.MacAddress)
            .HasMaxLength(12)
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

         builder.HasOne(x => x.Client)
            .WithMany()
            .HasForeignKey(x => x.ClientId);

         builder.HasOne(x => x.Location)
            .WithMany()
            .HasForeignKey(x => x.LocationId);

         builder.HasOne(x => x.CreatedBy)
            .WithMany()
            .HasForeignKey(x => x.CreatedById);
      }
   }
}
