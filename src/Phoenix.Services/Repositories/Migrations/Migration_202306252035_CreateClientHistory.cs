using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Clients;
using Phoenix.Entities.Locations;
using Phoenix.Entities.Users;
using Phoenix.Services.Extensions;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(Migration_202306252035_CreateClientHistory))]
   internal sealed class Migration_202306252035_CreateClientHistory : MigrationBase
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
               Hostname = table.Column<string>(name: nameof(ClientHistory.Hostname), maxLength: 66, defaultValue: string.Empty),
               ClientVersion = table.Column<string>(name: nameof(ClientHistory.ClientVersion), maxLength: 20, defaultValue: string.Empty),
               IsActive = table.Column<bool>(name: nameof(ClientHistory.IsActive), defaultValue: default(bool)),
               CreatedById = table.Column<int>(name: nameof(ClientHistory.CreatedById)),
               CreateDate = table.Column<DateTime>(name: nameof(ClientHistory.CreateDate), precision: 0, defaultValue: default(DateTime)),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(ClientHistory)}_{nameof(ClientHistory.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(ClientHistory)}_{nameof(ClientHistory.Client)}", x => x.ClientId, principalTable: nameof(Client), principalColumn: nameof(Client.Id));
               table.ForeignKey($"FK_{nameof(ClientHistory)}_{nameof(ClientHistory.Location)}", x => x.LocationId, principalTable: nameof(Location), principalColumn: nameof(Location.Id));
               table.ForeignKey($"FK_{nameof(ClientHistory)}_{nameof(ClientHistory.CreatedBy)}", x => x.CreatedById, principalTable: nameof(User), principalColumn: nameof(User.Id));
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(ClientHistory));
      }
   }
}
