using System;

namespace Phoenix.Entities.Base
{
   public abstract class MetricBase : EntityBase
   {
      public bool IsActive { get; set; }
      public byte[] Version { get; private set; }

      public MetricBase()
      {
         Version = Array.Empty<byte>();
      }
   }
}
