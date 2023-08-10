using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Base;
using Phoenix.Models.Base.Dto;
using Phoenix.Models.Base.Queries;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Base
{
   internal abstract class QueryHandlerBase : HandlerBase
   {
      protected readonly IMapper _mapper;

      public QueryHandlerBase(UnitOfWork uow, IMapper mapper) : base(uow)
      {
         _mapper = mapper;
      }

      protected async Task<IReadOnlyCollection<R>> GetPlcChartAsync<S, R>(DbSet<S> plcs, GetPlcChartQueryBase request, CancellationToken cancellationToken) where S : PlcBase where R : PlcChartDtoBase
      {
         DateTime dateTime = request.Date.ToDateTime(TimeOnly.MinValue);

         return await plcs
            .AsNoTracking()
            .Where(x =>
               x.Date >= dateTime &&
               x.Date < dateTime.AddDays(1) &&
               x.DeviceId == request.DeviceId
            )
            .ProjectTo<R>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
      }

      protected Task<R?> GetPlcLastAsync<S, R>(DbSet<S> plcs, GetPlcLastQueryBase request, CancellationToken cancellationToken) where S : PlcBase where R : PlcDtoBase
      {
         return plcs
            .AsNoTracking()
            .Include(x => x.Device)
            .Where(x => x.DeviceId == request.DeviceId)
            .OrderByDescending(x => x.Date)
            .ProjectTo<R>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
      }
   }
}
