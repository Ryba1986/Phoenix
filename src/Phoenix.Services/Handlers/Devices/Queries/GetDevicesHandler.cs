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
   internal sealed class GetDevicesHandler : HandlerBase, IRequestHandler<GetDevicesQuery, IReadOnlyCollection<DeviceDto>>
   {
      public GetDevicesHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<DeviceDto>> Handle(GetDevicesQuery request, CancellationToken cancellationToken)
      {
         return await _uow.Device
            .AsNoTracking()
            .Include(x => x.Location)
            .OrderBy(x => x.Location.Name)
            .ThenBy(x => x.Name)
            .Select(x => x.ToDeviceDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
