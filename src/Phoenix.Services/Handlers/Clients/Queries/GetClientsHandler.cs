using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Clients.Dto;
using Phoenix.Models.Clients.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Mappings;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Clients.Queries
{
   internal sealed class GetClientsHandler : HandlerBase, IRequestHandler<GetClientsQuery, IReadOnlyCollection<ClientDto>>
   {
      public GetClientsHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
      {
         return await _uow.Client
            .AsNoTracking()
            .Include(x => x.Location)
            .OrderBy(x => x.Location.Name)
            .ThenBy(x => x.MacAddress)
            .Select(x => x.ToClientDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
