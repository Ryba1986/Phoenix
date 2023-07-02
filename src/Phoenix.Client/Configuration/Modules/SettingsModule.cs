using Autofac;
using Microsoft.Extensions.Configuration;
using Phoenix.Client.Settings;
using Phoenix.Shared.Extensions;

namespace Phoenix.Client.Configuration.Modules
{
   internal sealed class SettingsModule : Module
   {
      private readonly IConfiguration _configuration;

      public SettingsModule(IConfiguration configuration)
      {
         _configuration = configuration;
      }

      protected override void Load(ContainerBuilder builder)
      {
         builder
            .RegisterInstance(_configuration.GetSettings<PhoenixSettings>())
            .SingleInstance();
      }
   }
}
