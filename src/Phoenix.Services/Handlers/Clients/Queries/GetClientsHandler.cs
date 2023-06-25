using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Clients.Dto;
using Phoenix.Models.Clients.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Clients.Queries
{
   internal sealed class GetClientsHandler : QueryHandlerBase, IRequestHandler<GetClientsQuery, IReadOnlyCollection<ClientDto>>
   {
      public GetClientsHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<IReadOnlyCollection<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
      {
         return await _uow.Client
            .AsNoTracking()
            .Include(x => x.Location)
            .OrderByDescending(x => x.IsActive)
            .ThenBy(x => x.Location.Name)
            .ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
      }
   }
}
