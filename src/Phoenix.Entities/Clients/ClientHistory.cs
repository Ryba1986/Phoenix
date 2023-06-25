using Phoenix.Entities.Base;
using Phoenix.Entities.Locations;

namespace Phoenix.Entities.Clients
{
   public sealed class ClientHistory : HistoryBase
   {
      public int ClientId { get; init; }
      public Client Client { get; init; }

      public int? LocationId { get; init; }
      public Location Location { get; init; }

      public string MacAddress { get; init; }

      public ClientHistory()
      {
         Client = null!;
         Location = null!;
         MacAddress = string.Empty;
      }
   }
}
