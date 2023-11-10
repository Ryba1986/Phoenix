using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Devices.Dto
{
   public class DeviceHistoryDto : HistoryDtoBase
   {
      public string Name { get; init; }
      public string LocationName { get; init; }
      public string PlcType { get; init; }
      public string ModbusId { get; init; }
      public string BoundRate { get; init; }
      public string DataBits { get; init; }
      public string Parity { get; init; }
      public string StopBits { get; init; }
      public string SerialNumber { get; init; }
      public string ReportSequence { get; init; }
      public bool IncludeReport { get; init; }

      public DeviceHistoryDto()
      {
         Name = string.Empty;
         LocationName = string.Empty;
         PlcType = string.Empty;
         ModbusId = string.Empty;
         BoundRate = string.Empty;
         DataBits = string.Empty;
         Parity = string.Empty;
         StopBits = string.Empty;
         SerialNumber = string.Empty;
         ReportSequence = string.Empty;
      }
   }
}
