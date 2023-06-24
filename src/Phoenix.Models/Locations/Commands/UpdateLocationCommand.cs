using Phoenix.Models.Base.Commands;

namespace Phoenix.Models.Locations.Commands
{
   public sealed class UpdateLocationCommand : UpdateCommandBase
   {
      public string Name { get; init; }
      public bool IncludeReport { get; init; }

      public UpdateLocationCommand()
      {
         Name = string.Empty;
      }
   }
}
