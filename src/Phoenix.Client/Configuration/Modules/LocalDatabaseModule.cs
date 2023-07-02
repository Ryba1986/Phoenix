using System.IO;
using Autofac;
using LiteDB;
using Microsoft.Extensions.Hosting;

namespace Phoenix.Client.Configuration.Modules
{
   internal sealed class LocalDatabaseModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         builder
            .Register((IHostEnvironment environment) =>
            {
               return new LiteRepository(new LiteDatabase($"{environment.ContentRootPath}{Path.DirectorySeparatorChar}{nameof(Phoenix)}{nameof(Client)}Db.db")
               {
                  CheckpointSize = 10,
                  UtcDate = false,
               });
            })
            .As<ILiteRepository>()
            .SingleInstance();
      }
   }
}
