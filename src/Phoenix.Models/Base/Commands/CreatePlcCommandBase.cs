using System;

namespace Phoenix.Models.Base.Commands
{
   public abstract class CreatePlcCommandBase : CommandBase
   {
      public int DeviceId { get; init; }
      public DateTime Date { get; init; }
      public string SerialNumber { get; init; }
      public int ClientId { get; private set; }

      public long Id => Date.Ticks;

      public CreatePlcCommandBase()
      {
         SerialNumber = string.Empty;
      }

      public override void SetId(int id)
      {
         ClientId = id;
      }
   }
}
