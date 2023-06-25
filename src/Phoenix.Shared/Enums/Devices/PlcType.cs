using System.ComponentModel;

namespace Phoenix.Shared.Enums.Devices
{
   public enum PlcType : byte
   {
      [Description("Kamstrup")]
      Kamstrup = 1,

      [Description("Climatix")]
      Climatix = 2,

      [Description("Rvd145")]
      Rvd145 = 3,
   }
}
