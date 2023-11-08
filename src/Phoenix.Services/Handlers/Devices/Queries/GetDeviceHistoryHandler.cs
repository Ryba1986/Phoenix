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
   internal sealed class GetDeviceHistoryHandler : HandlerBase, IRequestHandler<GetDeviceHistoryQuery, IReadOnlyCollection<DeviceHistoryDto>>
   {
      public GetDeviceHistoryHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<DeviceHistoryDto>> Handle(GetDeviceHistoryQuery request, CancellationToken cancellationToken)
      {
         return await _uow.DeviceHistory
            .AsNoTracking()
            .Include(x => x.Location)
            .Include(x => x.CreatedBy)
            .Where(x => x.DeviceId == request.DeviceId)
            .OrderByDescending(x => x.CreateDate)
            .Select(x => x.ToDeviceHistoryDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
