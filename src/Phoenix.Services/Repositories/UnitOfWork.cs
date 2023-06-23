using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Roles;

namespace Phoenix.Services.Repositories
{
   internal sealed class UnitOfWork : DbContext
   {
      public readonly DbSet<Role> Role;
      public readonly DbSet<RolePermission> RolePermission;

      public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options)
      {
         Role = Set<Role>();
         RolePermission = Set<RolePermission>();
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
      }
   }
}
