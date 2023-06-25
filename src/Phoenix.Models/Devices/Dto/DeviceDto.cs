using Phoenix.Models.Base.Dto;
using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Models.Devices.Dto
{
   public sealed class DeviceDto : MetricDtoBase
   {
      public int LocationId { get; init; }
      public string Name { get; init; }
      public DeviceType DeviceType { get; init; }
      public PlcType PlcType { get; init; }
      public byte ModbusId { get; init; }
      public SerialBoundRate BoundRate { get; init; }
      public SerialDataBits DataBits { get; init; }
      public SerialParity Parity { get; init; }
      public SerialStopBits StopBits { get; init; }
      public string SerialNumber { get; init; }
      public bool IncludeReport { get; init; }

      public DeviceDto()
      {
         Name = string.Empty;
         SerialNumber = string.Empty;
      }
   }
}
