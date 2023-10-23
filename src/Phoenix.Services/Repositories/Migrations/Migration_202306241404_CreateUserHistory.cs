using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Roles;
using Phoenix.Entities.Users;
using Phoenix.Services.Extensions;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(Migration_202306241404_CreateUserHistory))]
   internal sealed class Migration_202306241404_CreateUserHistory : MigrationBase
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(UserHistory),
            columns: table => new
            {
               Id = table.Column<int>(name: nameof(UserHistory.Id)).AddIdentity(),
               UserId = table.Column<int>(name: nameof(UserHistory.UserId)),
               RoleId = table.Column<int>(name: nameof(UserHistory.RoleId), nullable: true),
               Name = table.Column<string>(name: nameof(UserHistory.Name), maxLength: 50, defaultValue: string.Empty),
               Email = table.Column<string>(name: nameof(UserHistory.Email), maxLength: 50, defaultValue: string.Empty),
               IsActive = table.Column<bool>(name: nameof(UserHistory.IsActive), defaultValue: default(bool)),
               CreatedById = table.Column<int>(name: nameof(UserHistory.CreatedById)),
               CreateDate = table.Column<DateTime>(name: nameof(UserHistory.CreateDate), precision: 0, defaultValue: default(DateTime)),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(UserHistory)}_{nameof(UserHistory.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(UserHistory)}_{nameof(UserHistory.User)}", x => x.UserId, principalTable: nameof(User), principalColumn: nameof(User.Id));
               table.ForeignKey($"FK_{nameof(UserHistory)}_{nameof(UserHistory.Role)}", x => x.RoleId, principalTable: nameof(Role), principalColumn: nameof(Role.Id));
               table.ForeignKey($"FK_{nameof(UserHistory)}_{nameof(UserHistory.CreatedBy)}", x => x.CreatedById, principalTable: nameof(User), principalColumn: nameof(User.Id));
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(UserHistory));
      }
   }
}
