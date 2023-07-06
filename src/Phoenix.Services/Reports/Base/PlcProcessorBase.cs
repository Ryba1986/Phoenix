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
      protected const string MeterSheet = "Meter";
      protected const string PlcSheet = "Plc";

      public PlcProcessorBase(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      protected async Task<IReadOnlyDictionary<int, TResult[]>> GetPlcDataAsync<TSource, TResult>(DbSet<TSource> plc, DateOnly date, ITypeProcessor typeProcessor, CancellationToken cancellationToken) where TSource : PlcBase where TResult : PlcReportDtoBase
      {
         DateRange range = typeProcessor.GetRange(date);

         IReadOnlyCollection<TResult> result = await plc
            .AsNoTracking()
            .Where(x =>
               x.Date >= range.Start &&
               x.Date < range.End
            )
            .GroupBy(typeProcessor.GetPlcGroup<TSource>())
            .ProjectTo<TResult>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);

         return result
            .GroupBy(x => x.DeviceId)
            .ToDictionary(x => x.Key, x => x.ToArray());
      }
   }
}
