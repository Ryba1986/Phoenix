using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Base;
using Phoenix.Entities.Clients;
using Phoenix.Entities.Devices;
using Phoenix.Models.Base.Commands;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Helpers
{
   internal static class PlcHandlerHelper
   {
      public static async Task<Result> AddPlcAsync<T>(UnitOfWork uow, CreatePlcCommandBase request, T plc, CancellationToken cancellationToken) where T : PlcBase
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

         if (device.SerialNumber != request.SerialNumber && !string.IsNullOrWhiteSpace(request.SerialNumber))
         {
            device.SerialNumber = request.SerialNumber;
         }

         uow.Add(plc);

         await uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
