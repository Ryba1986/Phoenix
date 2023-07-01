using Phoenix.Models.Base.Dto;
using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Models.Devices.Dto
{
   public sealed class DeviceReportDto : ReportDtoBase
   {
      public int LocationId { get; init; }
      public DeviceType DeviceType { get; init; }
      public PlcType PlcType { get; init; }
   }
}
