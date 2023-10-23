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
         RegisterPlcTypeProcessors(builder);
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

      private static void RegisterPlcTypeProcessors(ContainerBuilder builder)
      {
         builder
            .RegisterType<DayTypeProcessor>()
            .Keyed<ITypeProcessor>(PlcReportType.Day);

         builder
            .RegisterType<MonthTypeProcessor>()
            .Keyed<ITypeProcessor>(PlcReportType.Month);

         builder
            .RegisterType<YearTypeProcessor>()
            .Keyed<ITypeProcessor>(PlcReportType.Year);

         builder
            .RegisterType<YearByDayTypeProcessor>()
            .Keyed<ITypeProcessor>(PlcReportType.YearByDay);
      }
   }
}
