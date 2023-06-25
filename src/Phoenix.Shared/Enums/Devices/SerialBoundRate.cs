using System.ComponentModel;

namespace Phoenix.Shared.Enums.Devices
{
   public enum SerialBoundRate : short
   {
      [Description("4800")]
      B4800 = 4800,

      [Description("9600")]
      B9600 = 9600,

      [Description("19200")]
      B19200 = 19200,
   }
}
