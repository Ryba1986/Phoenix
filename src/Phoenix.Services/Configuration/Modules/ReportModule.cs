using Autofac;
using Phoenix.Services.Reports.Base;
using Phoenix.Services.Reports.Plcs;
using Phoenix.Services.Reports.Types;
using Phoenix.Shared.Enums.Devices;
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
         builder
            .RegisterType<ClimatixPlcProcessor>()
            .Keyed<IPlcProcessor>(PlcType.Climatix);

         builder
            .RegisterType<KamstrupPlcProcessor>()
            .Keyed<IPlcProcessor>(PlcType.Kamstrup);

         builder
            .RegisterType<Rvd145PlcProcessor>()
            .Keyed<IPlcProcessor>(PlcType.Rvd145);
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
