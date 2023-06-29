using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Clients;
using Phoenix.Entities.Devices;
using Phoenix.Models.Plcs.Climatixs.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Extensions;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Plcs.Climatixs.Commands
{
   internal sealed class CreateClimatixHandler : HandlerBase, IRequestHandler<CreateClimatixCommand, Result>
   {
      public CreateClimatixHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(CreateClimatixCommand request, CancellationToken cancellationToken)
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

         _uow.Climatix.Add(new()
         {
            DeviceId = request.DeviceId,
            Date = request.Date.RoundToSecond(),

            OutsideTemp = request.OutsideTemp,
            ChHighInletPresure = request.ChHighInletPresure,
            ChHighOutletPresure = request.ChHighOutletPresure,
            Alarm = request.Alarm,

            Ch1LowInletTemp = request.Ch1LowInletTemp,
            Ch1LowOutletTemp = request.Ch1LowOutletTemp,
            Ch1LowOutletPresure = request.Ch1LowOutletPresure,
            Ch1HeatCurveTemp = request.Ch1HeatCurveTemp,
            Ch1PumpAlarm = request.Ch1PumpAlarm,
            Ch1PumpStatus = request.Ch1PumpStatus,
            Ch1ValvePosition = request.Ch1ValvePosition,
            Ch1Status = request.Ch1Status,

            Ch2LowInletTemp = request.Ch2LowInletTemp,
            Ch2LowOutletTemp = request.Ch2LowOutletTemp,
            Ch2LowOutletPresure = request.Ch2LowOutletPresure,
            Ch2HeatCurveTemp = request.Ch2HeatCurveTemp,
            Ch2PumpAlarm = request.Ch2PumpAlarm,
            Ch2PumpStatus = request.Ch2PumpStatus,
            Ch2ValvePosition = request.Ch2ValvePosition,
            Ch2Status = request.Ch2Status,

            DhwTemp = request.DhwTemp,
            DhwTempSet = request.DhwTempSet,
            DhwPumpAlarm = request.DhwPumpAlarm,
            DhwPumpStatus = request.DhwPumpStatus,
            DhwValvePosition = request.DhwValvePosition,
            DhwStatus = request.DhwStatus,
         });

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
