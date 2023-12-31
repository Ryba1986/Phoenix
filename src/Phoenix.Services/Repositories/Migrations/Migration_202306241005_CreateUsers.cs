using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Roles;
using Phoenix.Entities.Users;
using Phoenix.Services.Extensions;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(Migration_202306241005_CreateUsers))]
   internal sealed class Migration_202306241005_CreateUsers : MigrationBase
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(User),
            columns: table => new
            {
               Id = table.Column<int>(name: nameof(User.Id)).AddIdentity(),
               RoleId = table.Column<int>(name: nameof(User.RoleId)),
               Name = table.Column<string>(name: nameof(User.Name), maxLength: 50, defaultValue: string.Empty),
               Email = table.Column<string>(name: nameof(User.Email), maxLength: 50, defaultValue: string.Empty),
               Password = table.Column<string>(name: nameof(User.Password), maxLength: 64, fixedLength: true, defaultValue: string.Empty),
               IsActive = table.Column<bool>(name: nameof(User.IsActive), defaultValue: default(bool)),
               Version = table.Column<short>(name: nameof(User.Version), defaultValue: default(short)),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(User)}_{nameof(User.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(User)}_{nameof(User.Role)}", x => x.RoleId, principalTable: nameof(Role), principalColumn: nameof(Role.Id));
               table.UniqueConstraint($"UK_{nameof(User)}_{nameof(User.Email)}", x => x.Email);
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(User));
      }
   }
}
