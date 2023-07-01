using Autofac;

namespace Phoenix.Services.Configuration.Modules
{
   internal sealed class ReportModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         RegisterPlcProcessors(builder);
         RegisterTypeProcessors(builder);
      }

      private static void RegisterPlcProcessors(ContainerBuilder builder)
      {
      }

      private static void RegisterTypeProcessors(ContainerBuilder builder)
      {
      }
   }
}
