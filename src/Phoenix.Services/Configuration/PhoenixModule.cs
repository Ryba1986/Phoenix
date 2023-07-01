using Autofac;
using Microsoft.Extensions.Configuration;
using Phoenix.Services.Configuration.Mappers;
using Phoenix.Services.Configuration.Modules;

namespace Phoenix.Services.Configuration
{
   public sealed class PhoenixModule : Module
   {
      private readonly IConfiguration _configuration;

      public PhoenixModule(IConfiguration configuration)
      {
         _configuration = configuration;
      }

      protected override void Load(ContainerBuilder builder)
      {
         RegisterMappers(builder);
         RegisterModules(builder);
      }

      private static void RegisterMappers(ContainerBuilder builder)
      {
         builder
            .RegisterInstance(AutoMapperConfig.Initialize())
            .SingleInstance();
      }

      private void RegisterModules(ContainerBuilder builder)
      {
         builder.RegisterModule<RepositoryModule>();
         builder.RegisterModule<MediatorModule>();
         builder.RegisterModule<ReportModule>();
         builder.RegisterModule(new SettingsModule(_configuration));
      }
   }
}
