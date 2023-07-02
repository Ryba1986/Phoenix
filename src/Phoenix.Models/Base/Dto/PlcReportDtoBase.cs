using System;

namespace Phoenix.Models.Base.Dto
{
   public abstract class PlcReportDtoBase
   {
      public DateTime Date { get; init; }
      public int DeviceId { get; init; }
   }
}
