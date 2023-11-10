using System;

namespace Phoenix.Models.Base.Dto
{
   public abstract class PlcDtoBase
   {
      public string DeviceName { get; init; }
      public DateTime Date { get; init; }

      public PlcDtoBase()
      {
         DeviceName = string.Empty;
      }
   }
}
