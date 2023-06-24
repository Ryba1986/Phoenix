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
   internal sealed class GetLocationsHandler : QueryHandlerBase, IRequestHandler<GetLocationsQuery, IReadOnlyCollection<LocationDto>>
   {
      public GetLocationsHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<IReadOnlyCollection<LocationDto>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
      {
         return await _uow.Location
            .AsNoTracking()
            .OrderByDescending(x => x.IsActive)
            .ThenBy(x => x.Name)
            .ProjectTo<LocationDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
      }
   }
}
