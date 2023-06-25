using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Devices.Dto;
using Phoenix.Models.Devices.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Devices.Queries
{
   internal sealed class GetDevicesByLocationHandler : QueryHandlerBase, IRequestHandler<GetDevicesByLocationQuery, IReadOnlyCollection<DeviceDto>>
   {
      public GetDevicesByLocationHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<IReadOnlyCollection<DeviceDto>> Handle(GetDevicesByLocationQuery request, CancellationToken cancellationToken)
      {
         return await _uow.Device
            .AsNoTracking()
            .Where(x =>
               x.LocationId == request.LocationId &&
               x.IsActive
            )
            .OrderBy(x => x.Name)
            .ProjectTo<DeviceDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
      }
   }
}
