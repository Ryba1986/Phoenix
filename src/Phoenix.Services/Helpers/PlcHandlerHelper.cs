using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Base;
using Phoenix.Entities.Clients;
using Phoenix.Entities.Devices;
using Phoenix.Entities.Users;
using Phoenix.Models.Base.Commands;
using Phoenix.Models.Base.Dto;
using Phoenix.Models.Base.Queries;
using Phoenix.Models.Plcs;
using Phoenix.Services.Reports.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Extensions;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Helpers
{
   internal static class PlcHandlerHelper
   {
      public const string BaseSheet = "Base";
      public const string MeterSheet = "Meter";
      public const string PlcSheet = "Plc";

      public static async Task<Result> AddPlcAsync<T>(UnitOfWork uow, CreatePlcCommandBase request, T plc, DateTime serverDate, CancellationToken cancellationToken) where T : PlcBase
      {
         Client? client = await uow.Client
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.ClientId, cancellationToken);

         if (client is null)
         {
            return Result.Success();
         }

         Device? device = await uow.Device.FirstOrDefaultAsync(x => x.Id == request.DeviceId, cancellationToken);
         if (device is null || device.LocationId != client.LocationId)
         {
            return Result.Success();
         }

         if (device.SerialNumber != request.SerialNumber)
         {
            User user = await uow.User
               .AsNoTracking()
               .FirstAsync(cancellationToken);

            uow.DeviceHistory.Add(new()
            {
               DeviceId = device.Id,
               SerialNumber = request.SerialNumber,
               IncludeReport = device.IncludeReport,
               IsActive = device.IsActive,
               CreatedById = user.Id,
               CreateDate = serverDate
            });

            device.SerialNumber = request.SerialNumber;
         }

         uow.Add(plc);

         await uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }

      public static async Task<IReadOnlyCollection<R>> GetPlcChartAsync<S, R>(DbSet<S> plcs, int deviceId, DateTime startDate, DateTime endDate, Expression<Func<S, R>> selector, CancellationToken cancellationToken) where S : PlcBase where R : PlcChartDtoBase
      {
         return await plcs
            .AsNoTracking()
            .Where(x =>
               x.Date >= startDate &&
               x.Date < endDate &&
               x.DeviceId == deviceId
            )
            .Select(selector)
            .ToArrayAsync(cancellationToken);
      }

      public static async Task<IReadOnlyDictionary<int, R[]>> GetPlcDataAsync<S, R>(DbSet<S> plc, Tuple<DateTime, DateTime> range, ITypeProcessor typeProcessor, Expression<Func<IGrouping<PlcGroupBy, S>, R>> selector, CancellationToken cancellationToken) where S : PlcBase where R : PlcReportDtoBase
      {
         IReadOnlyCollection<R> result = await plc
            .AsNoTracking()
            .Where(x =>
               x.Date >= range.Item1 &&
               x.Date < range.Item2
            )
            .GroupBy(typeProcessor.GetPlcGroup<S>())
            .Select(selector)
            .ToArrayAsync(cancellationToken);

         return result
            .GroupBy(x => x.DeviceId)
            .ToDictionary(x => x.Key, x => x.OrderBy(x => x.Date).ToArray());
      }

      public static Task<R?> GetPlcLastAsync<S, R>(DbSet<S> plcs, GetPlcLastQueryBase request, Expression<Func<S, R>> selector, CancellationToken cancellationToken) where S : PlcBase where R : PlcDtoBase
      {
         return plcs
            .AsNoTracking()
            .Where(x => x.DeviceId == request.DeviceId)
            .OrderByDescending(x => x.Date)
            .Select(selector)
            .FirstOrDefaultAsync(cancellationToken);
      }

      public static Task<bool> IsPlcExistAsync<T>(DbSet<T> plcs, CreatePlcCommandBase request, CancellationToken cancellationToken) where T : PlcBase
      {
         return plcs
            .AsNoTracking()
            .AnyAsync(x =>
               x.Date == request.Date.RoundToSecond() &&
               x.DeviceId == request.DeviceId
            , cancellationToken);
      }
   }
}
