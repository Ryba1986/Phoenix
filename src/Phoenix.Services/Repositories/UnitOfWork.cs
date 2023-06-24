using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Roles;
using Phoenix.Entities.Users;

namespace Phoenix.Services.Repositories
{
   internal sealed class UnitOfWork : DbContext
   {
      public readonly DbSet<Role> Role;
      public readonly DbSet<RoleHistory> RoleHistory;

      public readonly DbSet<RolePermission> RolePermission;

      public readonly DbSet<User> User;
      public readonly DbSet<UserHistory> UserHistory;

      public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options)
      {
         Role = Set<Role>();
         RoleHistory = Set<RoleHistory>();

         RolePermission = Set<RolePermission>();

         User = Set<User>();
         UserHistory = Set<UserHistory>();
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
      }
   }
}
