using Phoenix.Entities.Clients;
using Phoenix.Models.Clients.Dto;

namespace Phoenix.Services.Mappings
{
   internal static class ClientMappings
   {
      public static ClientDto ToClientDto(this Client client)
      {
         return new()
         {
            Id = client.Id,
            LocationId = client.LocationId,
            MacAddress = client.MacAddress,
            Hostname = client.Hostname,
            ClientVersion = client.ClientVersion,
            IsActive = client.IsActive,
            Version = client.Version,
         };
      }

      public static ClientHistoryDto ToClientHistoryDto(this ClientHistory clientHistory)
      {
         return new()
         {
            Id = clientHistory.Id,
            LocationName = clientHistory.Location?.Name ?? string.Empty,
            MacAddress = clientHistory.MacAddress,
            Hostname = clientHistory.Hostname,
            ClientVersion = clientHistory.ClientVersion,
            IsActive = clientHistory.IsActive,
            CreatedByName = clientHistory.CreatedBy.Name,
            CreateDate = clientHistory.CreateDate,
         };
      }
   }
}
