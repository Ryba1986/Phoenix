using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Clients.Dto
{
   public sealed class ClientHistoryDto : HistoryDtoBase
   {
      public string LocationName { get; init; }
      public string MacAddress { get; init; }

      public ClientHistoryDto()
      {
         LocationName = string.Empty;
         MacAddress = string.Empty;
      }
   }
}
