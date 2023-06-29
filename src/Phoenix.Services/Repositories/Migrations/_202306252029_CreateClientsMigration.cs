using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Clients;
using Phoenix.Entities.Locations;
using Phoenix.Services.Extensions;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(_202306252029_CreateClientsMigration))]
   internal sealed class _202306252029_CreateClientsMigration : DbMigration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(Client),
            columns: table => new
            {
               Id = table.Column<int>(name: nameof(Client.Id)).AddIdentity(),
               LocationId = table.Column<int>(name: nameof(Client.LocationId)),
               MacAddress = table.Column<string>(name: nameof(Client.MacAddress), maxLength: 12, fixedLength: true, defaultValue: string.Empty),
               Hostname = table.Column<string>(name: nameof(Client.Hostname), maxLength: 66, defaultValue: string.Empty),
               ClientVersion = table.Column<string>(name: nameof(Client.ClientVersion), maxLength: 20, defaultValue: string.Empty),
               IsActive = table.Column<bool>(name: nameof(Client.IsActive), defaultValue: default(bool)),
               Version = table.Column<byte[]>(name: nameof(Client.Version), rowVersion: true),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(Client)}_{nameof(Client.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(Client)}_{nameof(Client.Location)}", x => x.LocationId, nameof(Location), principalColumn: nameof(Location.Id));
               table.UniqueConstraint($"UK_{nameof(Client)}_{nameof(Client.MacAddress)}", x => x.MacAddress);
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(Client));
      }
   }
}
