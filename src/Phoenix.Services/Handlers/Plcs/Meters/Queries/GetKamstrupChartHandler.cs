using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Plcs.Meters.Dto;
using Phoenix.Models.Plcs.Meters.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Meters.Queries
{
   internal sealed class GetKamstrupChartHandler : QueryHandlerBase, IRequestHandler<GetKamstrupChartQuery, IReadOnlyCollection<KamstrupChartDto>>
   {
      public GetKamstrupChartHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<IReadOnlyCollection<KamstrupChartDto>> Handle(GetKamstrupChartQuery request, CancellationToken cancellationToken)
      {
         DateTime dateTime = request.Date.ToDateTime(TimeOnly.MinValue);

         return await _uow.Kamstrup
            .AsNoTracking()
            .Where(x =>
               x.DeviceId == request.DeviceId &&
               x.Date >= dateTime &&
               x.Date < dateTime.AddDays(1)
            )
            .ProjectTo<KamstrupChartDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
      }
   }
}
