using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Base;
using Phoenix.Entities.Clients;
using Phoenix.Entities.Devices;
using Phoenix.Entities.Users;
using Phoenix.Models.Base.Commands;
using Phoenix.Models.Base.Queries;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Extensions;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Helpers
{
   internal static class PlcHandlerHelper
   {
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

      public static IQueryable<T> GetPlcChartQuery<T>(DbSet<T> plcs, GetPlcChartQueryBase request) where T : PlcBase
      {
         DateTime dateTime = request.Date.ToDateTime(TimeOnly.MinValue);

         return plcs
            .AsNoTracking()
            .Where(x =>
               x.Date >= dateTime &&
               x.Date < dateTime.AddDays(1) &&
               x.DeviceId == request.DeviceId
            );
      }

      public static IQueryable<T> GetPlcLastQuery<T>(DbSet<T> plcs, GetPlcLastQueryBase request) where T : PlcBase
      {
         return plcs
            .AsNoTracking()
            .Include(x => x.Device)
            .Where(x => x.DeviceId == request.DeviceId)
            .OrderByDescending(x => x.Date);
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
