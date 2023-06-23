using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Roles;
using Phoenix.Services.Repositories.Migrations.Base;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration("202306232213_CreateRolePermissions")]
   internal sealed class RolePermissionMigration : DbMigration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(RolePermission),
            columns: table => new
            {
               Id = table.Column<int>(name: nameof(RolePermission.Id)),
               RoleId = table.Column<int>(name: nameof(RolePermission.RoleId)),
               Permission = table.Column<Permission>(name: nameof(RolePermission.Permission)),
               AccessLevel = table.Column<AccessLevel>(name: nameof(RolePermission.AccessLevel)),
               IsActive = table.Column<bool>(name: nameof(RolePermission.IsActive)),
               Version = table.Column<byte[]>(name: nameof(RolePermission.Version), rowVersion: true),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(RolePermission)}_{nameof(RolePermission.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(RolePermission)}_{nameof(RolePermission.RoleId)}", x => x.RoleId, nameof(Role), principalColumn: nameof(Role.Id));
               table.UniqueConstraint($"UK_{nameof(RolePermission)}_{nameof(RolePermission.RoleId)}_{nameof(RolePermission.Permission)}", x => new { x.RoleId, x.Permission });
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(RolePermission));
      }
   }
}
