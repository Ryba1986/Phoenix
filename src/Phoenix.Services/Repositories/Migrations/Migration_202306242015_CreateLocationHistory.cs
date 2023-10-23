using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Locations;
using Phoenix.Entities.Users;
using Phoenix.Services.Extensions;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(Migration_202306242015_CreateLocationHistory))]
   internal sealed class Migration_202306242015_CreateLocationHistory : MigrationBase
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(LocationHistory),
            columns: table => new
            {
               Id = table.Column<int>(name: nameof(LocationHistory.Id)).AddIdentity(),
               LocationId = table.Column<int>(name: nameof(LocationHistory.LocationId)),
               Name = table.Column<string>(name: nameof(LocationHistory.Name), maxLength: 30, defaultValue: string.Empty),
               IncludeReport = table.Column<bool>(name: nameof(LocationHistory.IncludeReport), defaultValue: default(bool)),
               IsActive = table.Column<bool>(name: nameof(LocationHistory.IsActive), defaultValue: default(bool)),
               CreatedById = table.Column<int>(name: nameof(LocationHistory.CreatedById)),
               CreateDate = table.Column<DateTime>(name: nameof(LocationHistory.CreateDate), precision: 0, defaultValue: default(DateTime)),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(LocationHistory)}_{nameof(LocationHistory.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(LocationHistory)}_{nameof(LocationHistory.Location)}", x => x.LocationId, principalTable: nameof(Location), principalColumn: nameof(Location.Id));
               table.ForeignKey($"FK_{nameof(LocationHistory)}_{nameof(LocationHistory.CreatedBy)}", x => x.CreatedById, principalTable: nameof(User), principalColumn: nameof(User.Id));
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(LocationHistory));
      }
   }
}
