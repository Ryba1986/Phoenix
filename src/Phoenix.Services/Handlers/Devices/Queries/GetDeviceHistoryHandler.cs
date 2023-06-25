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
   internal sealed class GetDeviceHistoryHandler : QueryHandlerBase, IRequestHandler<GetDeviceHistoryQuery, IReadOnlyCollection<DeviceHistoryDto>>
   {
      public GetDeviceHistoryHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
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
            .ProjectTo<DeviceHistoryDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
      }
   }
}
