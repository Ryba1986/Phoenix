using System;
using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Models.Base.Dto
{
   public abstract class PlcReportDtoBase
   {
      public int DeviceId { get; init; }
      public DeviceType DeviceType { get; init; }
      public DateTime Date { get; init; }
   }
}
