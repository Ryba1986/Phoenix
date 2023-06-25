using System.ComponentModel;

namespace Phoenix.Shared.Enums.Devices
{
   public enum SerialStopBits : byte
   {
      [Description("0")]
      Zero = 0,

      [Description("1")]
      One = 1,

      [Description("2")]
      Two = 2
   }
}
