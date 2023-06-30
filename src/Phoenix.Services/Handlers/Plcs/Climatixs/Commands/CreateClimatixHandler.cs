using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Entities.Plcs.Climatixs;
using Phoenix.Models.Plcs.Climatixs.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Helpers;
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

         Climatix newClimatix = new()
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
         };

         return await PlcHandlerHelper.AddPlcAsync(_uow, request, newClimatix, cancellationToken);
      }
   }
}
