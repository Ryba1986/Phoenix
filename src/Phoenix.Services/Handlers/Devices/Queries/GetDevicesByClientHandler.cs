using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Devices;
using Phoenix.Models.Devices.Dto;
using Phoenix.Models.Devices.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Devices.Queries
{
   internal sealed class GetDevicesByClientHandler : QueryHandlerBase, IRequestHandler<GetDevicesByClientQuery, IReadOnlyCollection<DeviceDto>>
   {
      public GetDevicesByClientHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<IReadOnlyCollection<DeviceDto>> Handle(GetDevicesByClientQuery request, CancellationToken cancellationToken)
      {
         IQueryable<Device> query =
            from d in _uow.Device
            join l in _uow.Location on d.LocationId equals l.Id
            join c in _uow.Client on l.Id equals c.LocationId
            where
               c.Id == request.ClientId &&
               c.IsActive &&
               l.IsActive &&
               d.IsActive
            orderby d.Name
            select d;

         return await query
            .AsNoTracking()
            .ProjectTo<DeviceDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
      }
   }
}
