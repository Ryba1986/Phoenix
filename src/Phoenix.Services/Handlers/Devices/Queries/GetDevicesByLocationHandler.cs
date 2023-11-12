using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Devices.Dto;
using Phoenix.Models.Devices.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Mappings;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Devices.Queries
{
   internal sealed class GetDevicesByLocationHandler : HandlerBase, IRequestHandler<GetDevicesByLocationQuery, IReadOnlyCollection<DeviceDto>>
   {
      public GetDevicesByLocationHandler(UnitOfWork uow) : base(uow)
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
            .OrderBy(x => x.Sequence)
            .Select(x => x.ToDeviceDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
