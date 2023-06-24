using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Locations;
using Phoenix.Entities.Users;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration("202306242015_CreateLocationHistory")]
   internal sealed class LocationHistoryMigration : DbMigration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(LocationHistory),
            columns: table => new
            {
               Id = AddIdentity(table.Column<int>(name: nameof(LocationHistory.Id))),
               LocationId = table.Column<int>(name: nameof(LocationHistory.LocationId)),
               Name = table.Column<string>(name: nameof(LocationHistory.Name), maxLength: 30, defaultValue: string.Empty),
               IncludeReport = table.Column<bool>(name: nameof(LocationHistory.IncludeReport), defaultValue: default(bool)),
               CreatedById = table.Column<int>(name: nameof(LocationHistory.CreatedById)),
               IsActive = table.Column<bool>(name: nameof(LocationHistory.IsActive), defaultValue: default(bool)),
               CreateDate = table.Column<DateTime>(name: nameof(LocationHistory.CreateDate), defaultValue: default(DateTime)),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(LocationHistory)}_{nameof(LocationHistory.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(LocationHistory)}_{nameof(LocationHistory.Location)}", x => x.LocationId, nameof(Location), principalColumn: nameof(Location.Id));
               table.ForeignKey($"FK_{nameof(LocationHistory)}_{nameof(LocationHistory.CreatedBy)}", x => x.CreatedById, nameof(User), principalColumn: nameof(User.Id));
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(LocationHistory));
      }
   }
}
