using Phoenix.Models.Base.Commands;

namespace Phoenix.Models.Locations.Commands
{
   public sealed class CreateLocationCommand : CreateCommandBase
   {
      public string Name { get; init; }
      public bool IncludeReport { get; init; }

      public CreateLocationCommand()
      {
         Name = string.Empty;
      }
   }
}
