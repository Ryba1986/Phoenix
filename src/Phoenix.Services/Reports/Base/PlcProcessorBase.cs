using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Base;
using Phoenix.Models.Base.Dto;
using Phoenix.Models.Plcs;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Reports.Base
{
   internal abstract class PlcProcessorBase : HandlerBase
   {
      public const string BaseSheet = "Base";
      public const string MeterSheet = "Meter";
      public const string PlcSheet = "Plc";

      public PlcProcessorBase(UnitOfWork uow) : base(uow)
      {
      }

      protected static async Task<IReadOnlyDictionary<int, R[]>> GetPlcDataAsync<S, R>(DbSet<S> plc, Tuple<DateTime, DateTime> range, ITypeProcessor typeProcessor, Expression<Func<IGrouping<PlcGroupBy, S>, R>> selector, CancellationToken cancellationToken) where S : PlcBase where R : PlcReportDtoBase
      {
         IReadOnlyCollection<R> result = await plc
            .AsNoTracking()
            .Include(x => x.Device)
            .ThenInclude(x => x.Location)
            .Where(x =>
               x.Date >= range.Item1 &&
               x.Date < range.Item2 &&
               x.Device.IncludeReport &&
               x.Device.Location.IncludeReport
            )
            .GroupBy(typeProcessor.GetPlcGroup<S>())
            .Select(selector)
            .ToArrayAsync(cancellationToken);

         return result
            .GroupBy(x => x.DeviceId)
            .ToDictionary(x => x.Key, x => x.OrderBy(x => x.Date).ToArray());
      }
   }
}
