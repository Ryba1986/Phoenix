using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Plcs.Rvds.Dto;
using Phoenix.Models.Plcs.Rvds.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Rvds.Queries
{
   internal sealed class GetRvd145ChartHandler : QueryHandlerBase, IRequestHandler<GetRvd145ChartQuery, IReadOnlyCollection<Rvd145ChartDto>>
   {
      public GetRvd145ChartHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<IReadOnlyCollection<Rvd145ChartDto>> Handle(GetRvd145ChartQuery request, CancellationToken cancellationToken)
      {
         DateTime dateTime = request.Date.ToDateTime(TimeOnly.MinValue);

         return await _uow.Rvd145
            .AsNoTracking()
            .Where(x =>
               x.DeviceId == request.DeviceId &&
               x.Date >= dateTime &&
               x.Date < dateTime.AddDays(1)
            )
            .ProjectTo<Rvd145ChartDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
      }
   }
}
