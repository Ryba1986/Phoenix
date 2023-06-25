using Phoenix.Models.Base.Commands;

namespace Phoenix.Models.Clients.Commands
{
   public sealed class CreateClientCommand : CreateCommandBase
   {
      public int LocationId { get; init; }
      public string MacAddress { get; init; }

      public CreateClientCommand()
      {
         MacAddress = string.Empty;
      }
   }
}
