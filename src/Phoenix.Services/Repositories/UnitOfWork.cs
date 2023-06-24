using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Roles;
using Phoenix.Entities.Users;

namespace Phoenix.Services.Repositories
{
   internal sealed class UnitOfWork : DbContext
   {
      public readonly DbSet<Role> Role;
      public readonly DbSet<RolePermission> RolePermission;

      public readonly DbSet<User> User;

      public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options)
      {
         Role = Set<Role>();
         RolePermission = Set<RolePermission>();

         User = Set<User>();
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
      }
   }
}
