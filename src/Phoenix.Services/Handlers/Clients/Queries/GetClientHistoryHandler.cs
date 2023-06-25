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
   internal sealed class GetClientHistoryHandler : QueryHandlerBase, IRequestHandler<GetClientHistoryQuery, IReadOnlyCollection<ClientHistoryDto>>
   {
      public GetClientHistoryHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<IReadOnlyCollection<ClientHistoryDto>> Handle(GetClientHistoryQuery request, CancellationToken cancellationToken)
      {
         return await _uow.ClientHistory
            .AsNoTracking()
            .Include(x => x.Location)
            .Where(x => x.ClientId == request.ClientId)
            .OrderByDescending(x => x.CreateDate)
            .ProjectTo<ClientHistoryDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
      }
   }
}
