using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Clients;
using Phoenix.Entities.Devices;
using Phoenix.Entities.Locations;
using Phoenix.Entities.Plcs.Climatixs;
using Phoenix.Entities.Plcs.Meters;
using Phoenix.Entities.Plcs.Rvds;
using Phoenix.Entities.Roles;
using Phoenix.Entities.Users;

namespace Phoenix.Services.Repositories
{
   internal sealed class UnitOfWork : DbContext
   {
      public readonly DbSet<Client> Client;
      public readonly DbSet<ClientHistory> ClientHistory;

      public readonly DbSet<Device> Device;
      public readonly DbSet<DeviceHistory> DeviceHistory;

      public readonly DbSet<Location> Location;
      public readonly DbSet<LocationHistory> LocationHistory;

      public readonly DbSet<Role> Role;
      public readonly DbSet<RoleHistory> RoleHistory;

      public readonly DbSet<RolePermission> RolePermission;

      public readonly DbSet<User> User;
      public readonly DbSet<UserHistory> UserHistory;

      public readonly DbSet<Climatix> Climatix;
      public readonly DbSet<Kamstrup> Kamstrup;
      public readonly DbSet<Rvd145> Rvd145;

      public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options)
      {
         Client = Set<Client>();
         ClientHistory = Set<ClientHistory>();

         Device = Set<Device>();
         DeviceHistory = Set<DeviceHistory>();

         Location = Set<Location>();
         LocationHistory = Set<LocationHistory>();

         Role = Set<Role>();
         RoleHistory = Set<RoleHistory>();

         RolePermission = Set<RolePermission>();

         User = Set<User>();
         UserHistory = Set<UserHistory>();

         Climatix = Set<Climatix>();
         Kamstrup = Set<Kamstrup>();
         Rvd145 = Set<Rvd145>();
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
      }
   }
}
