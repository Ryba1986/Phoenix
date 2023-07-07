using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Models.Devices.Dto
{
   public sealed class DeviceReportDto
   {
      public int Id { get; init; }
      public string Name { get; init; }
      public string LocationName { get; init; }
      public DeviceType DeviceType { get; init; }
      public PlcType PlcType { get; init; }
      public byte ReportSequence { get; init; }

      public DeviceReportDto()
      {
         Name = string.Empty;
         LocationName = string.Empty;
      }
   }
}
