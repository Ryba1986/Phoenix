using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Roles;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration("202306231737_CreateRoles")]
   internal sealed class RoleMigration : Migration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(Role),
            columns: table => new
            {
               Id = table.Column<int>(nameof(Role.Id)),
               Name = table.Column<string>(nameof(Role.Name), maxLength: 50),
               IsActive = table.Column<bool>(nameof(Role.IsActive)),
               Version = table.Column<byte[]>(nameof(Role.Version), rowVersion: true),
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
