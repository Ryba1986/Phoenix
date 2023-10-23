using System.Collections.Generic;
using MediatR;
using Phoenix.Models.Clients.Dto;

namespace Phoenix.Models.Clients.Queries
{
   public sealed class GetClientHistoryQuery : IRequest<IReadOnlyCollection<ClientHistoryDto>>
   {
      public int ClientId { get; init; }
   }
}
