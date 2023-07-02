using Autofac;
using Microsoft.Extensions.Configuration;
using Phoenix.Client.Configuration.Modules;

namespace Phoenix.Client.Configuration
{
   internal sealed class PhoenixModule : Module
   {
      private readonly IConfiguration _configuration;

      public PhoenixModule(IConfiguration configuration)
      {
         _configuration = configuration;
      }

      protected override void Load(ContainerBuilder builder)
      {
         RegisterModules(builder);
      }

      private void RegisterModules(ContainerBuilder builder)
      {
         builder.RegisterModule<ApiClientModule>();
         builder.RegisterModule<LocalDatabaseModule>();
         builder.RegisterModule<MediatorModule>();
         builder.RegisterModule(new SettingsModule(_configuration));
      }
   }
}
