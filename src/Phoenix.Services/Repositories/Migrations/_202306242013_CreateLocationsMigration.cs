using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Locations;
using Phoenix.Services.Extensions;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(_202306242013_CreateLocationsMigration))]
   internal sealed class _202306242013_CreateLocationsMigration : DbMigration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(Location),
            columns: table => new
            {
               Id = table.Column<int>(name: nameof(Location.Id)).AddIdentity(),
               Name = table.Column<string>(name: nameof(Location.Name), maxLength: 30, defaultValue: string.Empty),
               IncludeReport = table.Column<bool>(name: nameof(Location.IncludeReport), defaultValue: default(bool)),
               IsActive = table.Column<bool>(name: nameof(Location.IsActive), defaultValue: default(bool)),
               Version = table.Column<byte[]>(name: nameof(Location.Version), rowVersion: true),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(Location)}_{nameof(Location.Id)}", x => x.Id);
               table.UniqueConstraint($"UK_{nameof(Location)}_{nameof(Location.Name)}", x => x.Name);
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(Location));
      }
   }
}
