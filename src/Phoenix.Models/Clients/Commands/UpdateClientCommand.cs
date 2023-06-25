using Phoenix.Models.Base.Commands;

namespace Phoenix.Models.Clients.Commands
{
   public sealed class UpdateClientCommand : UpdateCommandBase
   {
      public int LocationId { get; init; }
      public string MacAddress { get; init; }

      public UpdateClientCommand()
      {
         MacAddress = string.Empty;
      }
   }
}
