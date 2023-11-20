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
   internal sealed class GetClimatixChartDayHandler : HandlerBase, IRequestHandler<GetClimatixChartDayQuery, IReadOnlyCollection<ClimatixChartDto>>
   {
      public GetClimatixChartDayHandler(UnitOfWork uow) : base(uow)
      {
      }

      public Task<IReadOnlyCollection<ClimatixChartDto>> Handle(GetClimatixChartDayQuery request, CancellationToken cancellationToken)
      {
         return PlcHandlerHelper.GetPlcChartAsync(_uow.Climatix, request, x => x.ToClimatixChartDto(), cancellationToken);
      }
   }
}
