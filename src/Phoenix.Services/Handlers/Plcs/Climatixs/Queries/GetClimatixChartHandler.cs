using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Models.Plcs.Climatixs.Dto;
using Phoenix.Models.Plcs.Climatixs.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Helpers;
using Phoenix.Services.Mappings;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Climatixs.Queries
{
   internal sealed class GetClimatixChartHandler : HandlerBase, IRequestHandler<GetClimatixChartQuery, IReadOnlyCollection<ClimatixChartDto>>
   {
      public GetClimatixChartHandler(UnitOfWork uow) : base(uow)
      {
      }

      public Task<IReadOnlyCollection<ClimatixChartDto>> Handle(GetClimatixChartQuery request, CancellationToken cancellationToken)
      {
         return PlcHandlerHelper.GetPlcChartAsync(_uow.Climatix, request.DeviceId, request.StartDate, x => x.ToClimatixChartDto(), cancellationToken);
      }
   }
}
