namespace Phoenix.Models.Base.Commands
{
   public abstract class CreateCommandBase : CommandBase
   {
      public bool IsActive { get; init; }
      public int CreatedById { get; private set; }

      public override void SetId(int id)
      {
         CreatedById = id;
      }
   }
}
