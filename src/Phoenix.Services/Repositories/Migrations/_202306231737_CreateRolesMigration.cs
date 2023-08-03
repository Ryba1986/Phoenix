using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Roles;
using Phoenix.Services.Extensions;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(_202306231737_CreateRolesMigration))]
   internal sealed class _202306231737_CreateRolesMigration : DbMigration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(Role),
            columns: table => new
            {
               Id = table.Column<int>(name: nameof(Role.Id)).AddIdentity(),
               Name = table.Column<string>(name: nameof(Role.Name), maxLength: 50, defaultValue: string.Empty),
               IsAdmin = table.Column<bool>(name: nameof(Role.IsAdmin), defaultValue: default(bool)),
               IsActive = table.Column<bool>(name: nameof(Role.IsActive), defaultValue: default(bool)),
               Version = table.Column<short>(name: nameof(Role.Version), defaultValue: default(short)),
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
