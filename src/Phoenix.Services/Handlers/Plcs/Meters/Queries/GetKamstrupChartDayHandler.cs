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
   internal sealed class GetKamstrupChartDayHandler : HandlerBase, IRequestHandler<GetKamstrupChartDayQuery, IReadOnlyCollection<KamstrupChartDto>>
   {
      public GetKamstrupChartDayHandler(UnitOfWork uow) : base(uow)
      {
      }

      public Task<IReadOnlyCollection<KamstrupChartDto>> Handle(GetKamstrupChartDayQuery request, CancellationToken cancellationToken)
      {
         return PlcHandlerHelper.GetPlcChartAsync(_uow.Kamstrup, request, x => x.ToKamstrupChartDto(), cancellationToken);
      }
   }
}
