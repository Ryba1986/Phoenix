using System;

namespace Phoenix.Models.Base.Dto
{
   public abstract class PlcChartDtoBase
   {
      public int DeviceId { get; init; }
      public DateTime Date { get; init; }
   }
}
