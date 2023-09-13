using System;

namespace Phoenix.Models.Base.Commands
{
   public abstract class UpdateCommandBase : CommandBase
   {
      public int Id { get; init; }
      public bool IsActive { get; init; }
      public byte[] Version { get; init; }
      public int ModifiedById { get; private set; }

      public UpdateCommandBase()
      {
         Version = Array.Empty<byte>();
      }

      public override void SetId(int id)
      {
         ModifiedById = id;
      }
   }
}
