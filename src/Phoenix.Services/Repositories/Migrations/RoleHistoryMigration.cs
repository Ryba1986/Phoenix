using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Roles;
using Phoenix.Entities.Users;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration("202306241358_CreateRoleHistory")]
   internal sealed class RoleHistoryMigration : DbMigration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(RoleHistory),
            columns: table => new
            {
               Id = AddIdentity(table.Column<int>(name: nameof(RoleHistory.Id))),
               RoleId = table.Column<int>(name: nameof(RoleHistory.RoleId)),
               Name = table.Column<string>(name: nameof(RoleHistory.Name), maxLength: 50, defaultValue: string.Empty),
               CreatedById = table.Column<int>(name: nameof(RoleHistory.CreatedById)),
               IsActive = table.Column<bool>(name: nameof(RoleHistory.IsActive), defaultValue: default(bool)),
               CreateDate = table.Column<DateTime>(name: nameof(RoleHistory.CreateDate), defaultValue: default(DateTime)),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(RoleHistory)}_{nameof(RoleHistory.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(RoleHistory)}_{nameof(RoleHistory.Role)}", x => x.RoleId, nameof(Role), principalColumn: nameof(Role.Id));
               table.ForeignKey($"FK_{nameof(RoleHistory)}_{nameof(RoleHistory.CreatedBy)}", x => x.CreatedById, nameof(User), principalColumn: nameof(User.Id));
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(RoleHistory));
      }
   }
}
