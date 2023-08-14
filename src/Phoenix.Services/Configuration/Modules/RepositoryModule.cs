using System;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Phoenix.Services.Repositories;
using Phoenix.Services.Settings;

namespace Phoenix.Services.Configuration.Modules
{
   internal sealed class RepositoryModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         builder
            .Register((SqlSettings settings) =>
            {
               AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

               NpgsqlConnectionStringBuilder connectionStringBuilder = new()
               {
                  Host = settings.Server,
                  Port = settings.Port,
                  Database = settings.Database,
                  Username = settings.Username,
                  Password = settings.Password,
                  CommandTimeout = settings.CommandTimeout,
                  SslMode = SslMode.Prefer,
               };

               DbContextOptions<UnitOfWork> contextOptions = new DbContextOptionsBuilder<UnitOfWork>()
                  .UseNpgsql(connectionStringBuilder.ToString())
                  .Options;

               using UnitOfWork uow = new(contextOptions);
               uow.Database.Migrate();

               return contextOptions;
            })
            .AsSelf()
            .SingleInstance();

         builder
            .RegisterType<UnitOfWork>()
            .AsSelf();
      }
   }
}
