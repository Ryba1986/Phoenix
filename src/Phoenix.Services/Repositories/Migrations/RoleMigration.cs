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
               Id = table.Column<int>(name: nameof(Role.Id)),
               Name = table.Column<string>(name: nameof(Role.Name), maxLength: 50, defaultValue: string.Empty),
               IsActive = table.Column<bool>(name: nameof(Role.IsActive), defaultValue: default(bool)),
               Version = table.Column<byte[]>(name: nameof(Role.Version), rowVersion: true),
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
