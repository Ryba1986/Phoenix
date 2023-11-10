using System;

namespace Phoenix.Models.Base.Dto
{
   public abstract class PlcReportDtoBase
   {
      public int DeviceId { get; init; }
      public DateTime Date { get; init; }
   }
}
