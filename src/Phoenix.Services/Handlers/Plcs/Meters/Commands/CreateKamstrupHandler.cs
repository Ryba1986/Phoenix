using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Clients;
using Phoenix.Entities.Devices;
using Phoenix.Models.Plcs.Meters.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Extensions;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Plcs.Meters.Commands
{
   internal sealed class CreateKamstrupHandler : HandlerBase, IRequestHandler<CreateKamstrupCommand, Result>
   {
      public CreateKamstrupHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(CreateKamstrupCommand request, CancellationToken cancellationToken)
      {
         if (await IsPlcExistAsync(_uow.Kamstrup, request, cancellationToken))
         {
            return Result.Success();
         }

         Client? client = await _uow.Client
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.ClientId, cancellationToken);

         if (client is null)
         {
            return Result.Success();
         }

         Device? device = await _uow.Device.FirstOrDefaultAsync(x => x.Id == request.DeviceId, cancellationToken);
         if (device is null || device.LocationId != client.LocationId)
         {
            return Result.Success();
         }

         if (device.SerialNumber != request.SerialNumber)
         {
            device.SerialNumber = request.SerialNumber;
         }

         _uow.Kamstrup.Add(new()
         {
            DeviceId = request.DeviceId,
            Date = request.Date.RoundToSecond(),

            InletTemp = request.InletTemp,
            OutletTemp = request.OutletTemp,
            Power = request.Power,
            Volume = request.Volume,
            VolumeSummary = request.VolumeSummary,
            EnergySummary = request.EnergySummary,
            HourCount = request.HourCount,
            ErrorCode = request.ErrorCode,
         });

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
