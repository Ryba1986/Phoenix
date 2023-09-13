using System.Text;
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
               StringBuilder connectionBuilder = new();
               connectionBuilder.Append($"Server={settings.Server},{settings.Port};");
               connectionBuilder.Append($"Database={settings.Database};");
               connectionBuilder.Append($"User Id={settings.Username};");
               connectionBuilder.Append($"Password={settings.Password};");
               connectionBuilder.Append($"Encrypt={settings.IsEncrypt};");
               connectionBuilder.Append($"Command Timeout={settings.CommandTimeout};");

               DbContextOptions<UnitOfWork> contextOptions = new DbContextOptionsBuilder<UnitOfWork>()
                  .UseSqlServer(connectionBuilder.ToString())
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
