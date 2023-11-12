using System;
using Phoenix.Entities.Devices;

namespace Phoenix.Entities.Base
{
   public abstract class PlcBase
   {
      public int DeviceId { get; set; }
      public Device Device { get; set; }

      public DateTime Date { get; set; }

      public PlcBase()
      {
         Device = null!;
      }
   }
}
