using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Roles;
using Phoenix.Services.Extensions;
using Phoenix.Services.Repositories.Migrations.Base;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(_202306232213_CreateRolePermissionsMigration))]
   internal sealed class _202306232213_CreateRolePermissionsMigration : DbMigration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(RolePermission),
            columns: table => new
            {
               Id = table.Column<int>(name: nameof(RolePermission.Id)).AddIdentity(),
               RoleId = table.Column<int>(name: nameof(RolePermission.RoleId)),
               Permission = table.Column<Permission>(name: nameof(RolePermission.Permission), defaultValue: default(byte)),
               AccessLevel = table.Column<AccessLevel>(name: nameof(RolePermission.AccessLevel), defaultValue: default(byte)),
               IsActive = table.Column<bool>(name: nameof(RolePermission.IsActive), defaultValue: default(bool)),
               Version = table.Column<uint>(name: nameof(RolePermission.Version), rowVersion: true),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(RolePermission)}_{nameof(RolePermission.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(RolePermission)}_{nameof(RolePermission.Role)}", x => x.RoleId, nameof(Role), principalColumn: nameof(Role.Id));
               table.UniqueConstraint($"UK_{nameof(RolePermission)}_{nameof(RolePermission.Role)}_{nameof(RolePermission.Permission)}", x => new { x.RoleId, x.Permission });
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(RolePermission));
      }
   }
}
