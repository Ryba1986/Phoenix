using Phoenix.Models.Base.Commands;
using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Models.Devices.Commands
{
   public sealed class CreateDeviceCommand : CreateCommandBase
   {
      public int LocationId { get; init; }
      public string Name { get; init; }
      public PlcType PlcType { get; init; }
      public byte ModbusId { get; init; }
      public SerialBoundRate BoundRate { get; init; }
      public SerialDataBits DataBits { get; init; }
      public SerialParity Parity { get; init; }
      public SerialStopBits StopBits { get; init; }
      public byte Sequence { get; init; }
      public bool IncludeReport { get; init; }

      public CreateDeviceCommand()
      {
         Name = string.Empty;
      }
   }
}
