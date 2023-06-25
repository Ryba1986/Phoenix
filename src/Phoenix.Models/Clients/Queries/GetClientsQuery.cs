using System.Collections.Generic;
using MediatR;
using Phoenix.Models.Clients.Dto;

namespace Phoenix.Models.Clients.Queries
{
   public sealed class GetClientsQuery : IRequest<IReadOnlyCollection<ClientDto>>
   {
   }
}
