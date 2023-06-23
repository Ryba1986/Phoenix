using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Roles;

namespace Phoenix.Services.Repositories
{
   internal sealed class UnitOfWork : DbContext
   {
      public readonly DbSet<Role> Role;

      public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options)
      {
         Role = Set<Role>();
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
      }
   }
}
