using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Locations.Dto;
using Phoenix.Models.Locations.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Mappings;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Locations.Queries
{
   internal sealed class GetLocationHistoryHandler : HandlerBase, IRequestHandler<GetLocationHistoryQuery, IReadOnlyCollection<LocationHistoryDto>>
   {
      public GetLocationHistoryHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<LocationHistoryDto>> Handle(GetLocationHistoryQuery request, CancellationToken cancellationToken)
      {
         return await _uow.LocationHistory
            .AsNoTracking()
            .Include(x => x.CreatedBy)
            .Where(x => x.LocationId == request.LocationId)
            .Select(x => x.ToLocationHistoryDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
