using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Roles;
using Phoenix.Entities.Users;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration("202306241404_CreateUserHistory")]
   internal sealed class UserHistoryMigration : DbMigration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(UserHistory),
            columns: table => new
            {
               Id = AddIdentity(table.Column<int>(name: nameof(UserHistory.Id))),
               UserId = table.Column<int>(name: nameof(UserHistory.UserId)),
               RoleId = table.Column<int>(name: nameof(UserHistory.RoleId)),
               Name = table.Column<string>(name: nameof(UserHistory.Name), maxLength: 50, defaultValue: string.Empty),
               Email = table.Column<string>(name: nameof(UserHistory.Email), maxLength: 50, defaultValue: string.Empty),
               CreatedById = table.Column<int>(name: nameof(UserHistory.CreatedById)),
               IsActive = table.Column<bool>(name: nameof(UserHistory.IsActive), defaultValue: default(bool)),
               CreateDate = table.Column<DateTime>(name: nameof(UserHistory.CreateDate), defaultValue: default(DateTime)),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(UserHistory)}_{nameof(UserHistory.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(UserHistory)}_{nameof(UserHistory.User)}", x => x.UserId, nameof(User), principalColumn: nameof(User.Id));
               table.ForeignKey($"FK_{nameof(UserHistory)}_{nameof(UserHistory.Role)}", x => x.RoleId, nameof(Role), principalColumn: nameof(Role.Id));
               table.ForeignKey($"FK_{nameof(UserHistory)}_{nameof(UserHistory.CreatedBy)}", x => x.CreatedById, nameof(User), principalColumn: nameof(User.Id));
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(UserHistory));
      }
   }
}
