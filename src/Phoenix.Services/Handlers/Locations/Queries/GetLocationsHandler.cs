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
   internal sealed class GetLocationsHandler : HandlerBase, IRequestHandler<GetLocationsQuery, IReadOnlyCollection<LocationDto>>
   {
      public GetLocationsHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<LocationDto>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
      {
         return await _uow.Location
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .Select(x => x.ToLocationDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
