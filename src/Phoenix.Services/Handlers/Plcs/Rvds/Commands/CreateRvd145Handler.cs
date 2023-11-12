using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Entities.Plcs.Rvds;
using Phoenix.Models.Plcs.Rvds.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Helpers;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Extensions;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Plcs.Rvds.Commands
{
   internal sealed class CreateRvd145Handler : HandlerBase, IRequestHandler<CreateRvd145Command, Result>
   {
      public CreateRvd145Handler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(CreateRvd145Command request, CancellationToken cancellationToken)
      {
         if (await PlcHandlerHelper.IsPlcExistAsync(_uow.Rvd145, request, cancellationToken))
         {
            return Result.Success();
         }

         Rvd145 newRvd145 = new()
         {
            DeviceId = request.DeviceId,
            Date = request.Date.RoundToSecond(),

            OutsideTemp = request.OutsideTemp,
            ChHighInletPresure = request.ChHighInletPresure,
            Alarm = request.Alarm,

            Ch1HighOutletTemp = request.Ch1HighOutletTemp,
            Ch1LowInletTemp = request.Ch1LowInletTemp,
            Ch1LowOutletPresure = request.Ch1LowOutletPresure,
            Ch1HeatCurveTemp = request.Ch1HeatCurveTemp,
            Ch1PumpStatus = request.Ch1PumpStatus,
            Ch1Status = request.Ch1Status,

            DhwTemp = request.DhwTemp,
            DhwTempSet = request.DhwTempSet,
            DhwCirculationTemp = request.DhwCirculationTemp,
            DhwPumpStatus = request.DhwPumpStatus,
            DhwStatus = request.DhwStatus,
         };

         return await PlcHandlerHelper.AddPlcAsync(_uow, request, newRvd145, GetServerDate(), cancellationToken);
      }
   }
}
