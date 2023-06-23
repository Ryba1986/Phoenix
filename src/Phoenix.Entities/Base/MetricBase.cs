using System;

namespace Phoenix.Entities.Base
{
   public abstract class MetricBase : EntityBase
   {
      public bool IsActive { get; protected set; }
      public byte[] Version { get; private set; }

      public MetricBase(bool isActive)
      {
         Version = Array.Empty<byte>();

         IsActive = isActive;
      }
   }
}
