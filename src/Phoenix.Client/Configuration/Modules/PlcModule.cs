using Autofac;
using Phoenix.Client.Plcs.Base;
using Phoenix.Client.Plcs.Climatixs;
using Phoenix.Client.Plcs.Meters;
using Phoenix.Client.Plcs.Rvds;
using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Client.Configuration.Modules
{
   internal sealed class PlcModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         builder
            .RegisterType<ClimatixProcessor>()
            .Keyed<IPlcProcessor>(PlcType.Climatix);

         builder
            .RegisterType<KamstrupProcessor>()
            .Keyed<IPlcProcessor>(PlcType.Kamstrup);

         builder
            .RegisterType<Rvd145Processor>()
            .Keyed<IPlcProcessor>(PlcType.Rvd145);
      }
   }
}
