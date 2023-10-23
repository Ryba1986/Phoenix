using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Entities.Plcs.Meters;
using Phoenix.Models.Plcs.Meters.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Helpers;
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
         if (await PlcHandlerHelper.IsPlcExistAsync(_uow.Kamstrup, request, cancellationToken))
         {
            return Result.Success();
         }

         Kamstrup newKamstrup = new()
         {
            Date = request.Date.RoundToSecond(),
            DeviceId = request.DeviceId,

            InletTemp = request.InletTemp,
            OutletTemp = request.OutletTemp,
            Power = request.Power,
            Volume = request.Volume,
            VolumeSummary = request.VolumeSummary,
            EnergySummary = request.EnergySummary,
            HourCount = request.HourCount,
            ErrorCode = request.ErrorCode,
         };

         return await PlcHandlerHelper.AddPlcAsync(_uow, request, newKamstrup, GetServerDate(), cancellationToken);
      }
   }
}
