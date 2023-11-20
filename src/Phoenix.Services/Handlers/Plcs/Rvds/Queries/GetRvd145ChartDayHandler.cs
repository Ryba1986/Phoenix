using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Models.Plcs.Rvds.Dto;
using Phoenix.Models.Plcs.Rvds.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Helpers;
using Phoenix.Services.Mappings;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Rvds.Queries
{
   internal sealed class GetRvd145ChartDayHandler : HandlerBase, IRequestHandler<GetRvd145ChartDayQuery, IReadOnlyCollection<Rvd145ChartDto>>
   {
      public GetRvd145ChartDayHandler(UnitOfWork uow) : base(uow)
      {
      }

      public Task<IReadOnlyCollection<Rvd145ChartDto>> Handle(GetRvd145ChartDayQuery request, CancellationToken cancellationToken)
      {
         return PlcHandlerHelper.GetPlcChartAsync(_uow.Rvd145, request, x => x.ToRvd145ChartDto(), cancellationToken);
      }
   }
}
