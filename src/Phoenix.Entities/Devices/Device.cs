using Phoenix.Entities.Base;
using Phoenix.Entities.Locations;
using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Entities.Devices
{
   public sealed class Device : MetricBase
   {
      public int LocationId { get; set; }
      public Location Location { get; set; }

      public string Name { get; set; }
      public DeviceType DeviceType { get; set; }
      public PlcType PlcType { get; set; }
      public byte ModbusId { get; set; }
      public SerialBoundRate BoundRate { get; set; }
      public SerialDataBits DataBits { get; set; }
      public SerialParity Parity { get; set; }
      public SerialStopBits StopBits { get; set; }
      public string SerialNumber { get; set; }
      public bool IncludeReport { get; set; }

      public Device()
      {
         Location = null!;
         Name = string.Empty;
         SerialNumber = string.Empty;
      }
   }
}
