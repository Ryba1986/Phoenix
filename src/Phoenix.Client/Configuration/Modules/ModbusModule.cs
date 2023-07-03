using Autofac;
using NModbus;

namespace Phoenix.Client.Configuration.Modules
{
   internal sealed class ModbusModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         builder
            .RegisterType<ModbusFactory>()
            .As<IModbusFactory>();
      }
   }
}
