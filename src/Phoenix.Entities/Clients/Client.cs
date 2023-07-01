using Phoenix.Entities.Base;
using Phoenix.Entities.Locations;

namespace Phoenix.Entities.Clients
{
   public sealed class Client : MetricBase
   {
      public int LocationId { get; set; }
      public Location Location { get; set; }

      public string MacAddress { get; set; }
      public string Hostname { get; set; }
      public string ClientVersion { get; set; }

      public Client()
      {
         Location = null!;
         MacAddress = string.Empty;
         Hostname = string.Empty;
         ClientVersion = string.Empty;
      }
   }
}
