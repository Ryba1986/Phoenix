using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Phoenix.Services.Repositories.Migrations.Base
{
   [DbContext(typeof(UnitOfWork))]
   internal abstract class MigrationBase : Migration
   {
   }
}
