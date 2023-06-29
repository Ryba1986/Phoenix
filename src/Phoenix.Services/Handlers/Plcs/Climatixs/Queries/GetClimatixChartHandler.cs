using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Plcs.Climatixs.Dto;
using Phoenix.Models.Plcs.Climatixs.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Climatixs.Queries
{
   internal sealed class GetClimatixChartHandler : QueryHandlerBase, IRequestHandler<GetClimatixChartQuery, IReadOnlyCollection<ClimatixChartDto>>
   {
      public GetClimatixChartHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<IReadOnlyCollection<ClimatixChartDto>> Handle(GetClimatixChartQuery request, CancellationToken cancellationToken)
      {
         DateTime dateTime = request.Date.ToDateTime(TimeOnly.MinValue);

         return await _uow.Climatix
            .AsNoTracking()
            .Where(x =>
               x.DeviceId == request.DeviceId &&
               x.Date >= dateTime &&
               x.Date < dateTime.AddDays(1)
            )
            .ProjectTo<ClimatixChartDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
      }
   }
}
