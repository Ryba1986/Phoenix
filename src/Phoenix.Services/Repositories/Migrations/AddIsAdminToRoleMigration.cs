using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Roles;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration("202306282054_AddIsAdminToRoles")]
   internal sealed class AddIsAdminToRoleMigration : DbMigration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.AddColumn<bool>(nameof(Role.IsAdmin), nameof(Role), defaultValue: default(bool));
         migrationBuilder.AddColumn<bool>(nameof(RoleHistory.IsAdmin), nameof(RoleHistory), defaultValue: default(bool));
      }
   }
}
