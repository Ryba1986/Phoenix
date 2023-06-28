using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Phoenix.Services.Extensions
{
   internal static class MigrationExtensions
   {
      public static OperationBuilder<SqlOperation> AddTableCompression(this MigrationBuilder migrationBuilder, string name)
      {
         return migrationBuilder.Sql($"ALTER TABLE {name} REBUILD PARTITION = ALL WITH (DATA_COMPRESSION = PAGE);");
      }

      public static OperationBuilder<AddColumnOperation> AddIdentity(this OperationBuilder<AddColumnOperation> value)
      {
         return value.Annotation("SqlServer:Identity", "1, 1");
      }
   }
}
