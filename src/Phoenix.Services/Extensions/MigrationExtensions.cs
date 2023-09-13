using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Phoenix.Services.Extensions
{
   internal static class MigrationExtensions
   {
      public static OperationBuilder<SqlOperation> AddTableCompression(this MigrationBuilder migrationBuilder, string tableName)
      {
         return migrationBuilder.Sql($"ALTER TABLE {tableName} REBUILD PARTITION = ALL WITH (DATA_COMPRESSION = PAGE);");
      }

      public static OperationBuilder<AddColumnOperation> AddIdentity(this OperationBuilder<AddColumnOperation> value)
      {
         return value.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
      }
   }
}
