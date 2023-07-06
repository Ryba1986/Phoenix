using Autofac;
using Phoenix.Services.Reports.Base;
using Phoenix.Services.Reports.Types;
using Phoenix.Shared.Enums.Reports;

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
         builder
            .RegisterType<DayTypeProcessor>()
            .Keyed<ITypeProcessor>(ReportType.Day);

         builder
            .RegisterType<MonthTypeProcessor>()
            .Keyed<ITypeProcessor>(ReportType.Month);

         builder
            .RegisterType<YearTypeProcessor>()
            .Keyed<ITypeProcessor>(ReportType.Year);

         builder
            .RegisterType<YearByDayProcessor>()
            .Keyed<ITypeProcessor>(ReportType.YearByDay);
      }
   }
}
