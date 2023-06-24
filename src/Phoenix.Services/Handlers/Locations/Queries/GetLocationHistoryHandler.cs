using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Locations.Dto;
using Phoenix.Models.Locations.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Locations.Queries
{
   internal sealed class GetLocationHistoryHandler : QueryHandlerBase, IRequestHandler<GetLocationHistoryQuery, IReadOnlyCollection<LocationHistoryDto>>
   {
      public GetLocationHistoryHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<IReadOnlyCollection<LocationHistoryDto>> Handle(GetLocationHistoryQuery request, CancellationToken cancellationToken)
      {
         return await _uow.LocationHistory
            .AsNoTracking()
            .Include(x => x.CreatedBy)
            .Where(x => x.LocationId == request.LocationId)
            .OrderByDescending(x => x.CreateDate)
            .ProjectTo<LocationHistoryDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
      }
   }
}
