using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Clients.Dto
{
   public sealed class ClientDto : MetricDtoBase
   {
      public int LocationId { get; init; }
      public string MacAddress { get; init; }
      public string Hostname { get; init; }
      public string ClientVersion { get; init; }

      public ClientDto()
      {
         MacAddress = string.Empty;
         Hostname = string.Empty;
         ClientVersion = string.Empty;
      }
   }
}
