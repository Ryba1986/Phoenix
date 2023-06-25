using Phoenix.Entities.Base;
using Phoenix.Entities.Locations;
using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Entities.Devices
{
   public sealed class DeviceHistory : HistoryBase
   {
      public int DeviceId { get; init; }
      public Device Device { get; init; }

      public int? LocationId { get; init; }
      public Location? Location { get; init; }

      public string Name { get; init; }
      public DeviceType? DeviceType { get; init; }
      public PlcType? PlcType { get; init; }
      public byte? ModbusId { get; init; }
      public SerialBoundRate? BoundRate { get; init; }
      public SerialDataBits? DataBits { get; init; }
      public SerialParity? Parity { get; init; }
      public SerialStopBits? StopBits { get; init; }
      public bool IncludeReport { get; init; }

      public DeviceHistory()
      {
         Device = null!;
         Name = string.Empty;
      }
   }
}
