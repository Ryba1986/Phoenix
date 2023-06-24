using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Phoenix.Services.Repositories.Migrations.Base
{
   [DbContext(typeof(UnitOfWork))]
   internal abstract class DbMigration : Migration
   {
      public static OperationBuilder<AddColumnOperation> AddIdentity(OperationBuilder<AddColumnOperation> value)
      {
         return value.Annotation("SqlServer:Identity", "1, 1");
      }
   }
}
