using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Roles;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration("202306231737_CreateRoles")]
   internal sealed class RoleMigration : DbMigration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(Role),
            columns: table => new
            {
               Id = table.Column<int>(),
               Name = table.Column<string>(maxLength: 50),
               IsActive = table.Column<bool>(),
               Version = table.Column<byte[]>(rowVersion: true),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(Role)}_{nameof(Role.Id)}", x => x.Id);
               table.UniqueConstraint($"UK_{nameof(Role)}_{nameof(Role.Name)}", x => x.Name);
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(Role));
      }
   }
}
