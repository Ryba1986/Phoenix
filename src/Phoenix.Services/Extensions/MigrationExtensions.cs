using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Phoenix.Services.Extensions
{
   internal static class MigrationExtensions
   {
      public static OperationBuilder<AddColumnOperation> AddIdentity(this OperationBuilder<AddColumnOperation> value)
      {
         return value.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);
      }
   }
}
