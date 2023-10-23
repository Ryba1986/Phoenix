using Autofac;
using Microsoft.Extensions.Configuration;
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
         RegisterModules(builder);
      }

      private void RegisterModules(ContainerBuilder builder)
      {
         builder.RegisterModule<RepositoryModule>();
         builder.RegisterModule<ReportModule>();
         builder.RegisterModule<MediatorModule>();
         builder.RegisterModule(new SettingsModule(_configuration));
      }
   }
}
