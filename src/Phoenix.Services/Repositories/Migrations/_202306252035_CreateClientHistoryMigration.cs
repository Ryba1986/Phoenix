using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Clients;
using Phoenix.Entities.Locations;
using Phoenix.Entities.Users;
using Phoenix.Services.Extensions;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(_202306252035_CreateClientHistoryMigration))]
   internal sealed class _202306252035_CreateClientHistoryMigration : DbMigration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(ClientHistory),
            columns: table => new
            {
               Id = table.Column<int>(name: nameof(ClientHistory.Id)).AddIdentity(),
               ClientId = table.Column<int>(name: nameof(ClientHistory.ClientId)),
               LocationId = table.Column<int>(name: nameof(ClientHistory.LocationId), nullable: true),
               MacAddress = table.Column<string>(name: nameof(ClientHistory.MacAddress), maxLength: 12, defaultValue: string.Empty),
               CreatedById = table.Column<int>(name: nameof(ClientHistory.CreatedById)),
               IsActive = table.Column<bool>(name: nameof(ClientHistory.IsActive), defaultValue: default(bool)),
               CreateDate = table.Column<DateTime>(name: nameof(ClientHistory.CreateDate), defaultValue: default(DateTime)),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(ClientHistory)}_{nameof(ClientHistory.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(ClientHistory)}_{nameof(ClientHistory.Client)}", x => x.ClientId, nameof(Client), principalColumn: nameof(Client.Id));
               table.ForeignKey($"FK_{nameof(ClientHistory)}_{nameof(ClientHistory.Location)}", x => x.LocationId, nameof(Location), principalColumn: nameof(Location.Id));
               table.ForeignKey($"FK_{nameof(ClientHistory)}_{nameof(ClientHistory.CreatedBy)}", x => x.CreatedById, nameof(User), principalColumn: nameof(User.Id));
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(ClientHistory));
      }
   }
}
