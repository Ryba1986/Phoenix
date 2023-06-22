using Microsoft.EntityFrameworkCore;

namespace Phoenix.Services.Repositories
{
   internal sealed class UnitOfWork : DbContext
   {
      public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options)
      {
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
      }
   }
}
