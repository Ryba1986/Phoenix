using System;
using Autofac;
using Microsoft.EntityFrameworkCore;
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

               DbContextOptions<UnitOfWork> contextOptions = new DbContextOptionsBuilder<UnitOfWork>()
                  .UseNpgsql($"Server={settings.Server};Port={settings.Port};Database={settings.Database};User Id={settings.Username};Password={settings.Password};Command Timeout={settings.CommandTimeout};")
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
