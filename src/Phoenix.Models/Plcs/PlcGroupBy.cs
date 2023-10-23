using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Models.Plcs
{
   public readonly struct PlcGroupBy
   {
      public int DeviceId { get; init; }
      public DeviceType DeviceType { get; init; }
      public int DatePart { get; init; }
   }
}
