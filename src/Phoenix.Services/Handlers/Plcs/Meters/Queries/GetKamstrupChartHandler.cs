using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Models.Plcs.Meters.Dto;
using Phoenix.Models.Plcs.Meters.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Helpers;
using Phoenix.Services.Mappings;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Meters.Queries
{
   internal sealed class GetKamstrupChartHandler : HandlerBase, IRequestHandler<GetKamstrupChartQuery, IReadOnlyCollection<KamstrupChartDto>>
   {
      public GetKamstrupChartHandler(UnitOfWork uow) : base(uow)
      {
      }

      public Task<IReadOnlyCollection<KamstrupChartDto>> Handle(GetKamstrupChartQuery request, CancellationToken cancellationToken)
      {
         return PlcHandlerHelper.GetPlcChartAsync(_uow.Kamstrup, request.DeviceId, request.StartDate, x => x.ToKamstrupChartDto(), cancellationToken);
      }
   }
}
