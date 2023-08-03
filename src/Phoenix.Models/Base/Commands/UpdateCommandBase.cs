namespace Phoenix.Models.Base.Commands
{
   public abstract class UpdateCommandBase : CommandBase
   {
      public int Id { get; init; }
      public bool IsActive { get; init; }
      public short Version { get; init; }
      public int ModifiedById { get; private set; }

      public override void SetId(int id)
      {
         ModifiedById = id;
      }
   }
}
