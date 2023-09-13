using System;

namespace Phoenix.Models.Base.Dto
{
   public abstract class MetricDtoBase : DtoBase
   {
      public bool IsActive { get; init; }
      public byte[] Version { get; init; }

      public MetricDtoBase()
      {
         Version = Array.Empty<byte>();
      }
   }
}
