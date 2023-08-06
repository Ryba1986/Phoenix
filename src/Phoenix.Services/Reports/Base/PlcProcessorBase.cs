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
using Phoenix.Models.Utilities;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Reports.Base
{
   internal abstract class PlcProcessorBase : QueryHandlerBase
   {
      public const string BaseSheet = "Base";
      protected const string MeterSheet = "Meter";
      protected const string PlcSheet = "Plc";

      public PlcProcessorBase(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      protected async Task<IReadOnlyDictionary<int, R[]>> GetPlcDataAsync<S, R>(DbSet<S> plc, DateOnly date, ITypeProcessor typeProcessor, CancellationToken cancellationToken) where S : PlcBase where R : PlcReportDtoBase
      {
         DateRange range = typeProcessor.GetRange(date);

         IReadOnlyCollection<R> result = await plc
            .AsNoTracking()
            .Where(x =>
               x.Date >= range.Start &&
               x.Date < range.End
            )
            .GroupBy(typeProcessor.GetPlcGroup<S>())
            .ProjectTo<R>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);

         return result
            .GroupBy(x => x.DeviceId)
            .ToDictionary(
               x => x.Key,
               x => x.OrderBy(x => x.Date).ToArray()
            );
      }
   }
}
