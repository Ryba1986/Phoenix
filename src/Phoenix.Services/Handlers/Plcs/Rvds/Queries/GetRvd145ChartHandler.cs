using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Plcs.Rvds.Dto;
using Phoenix.Models.Plcs.Rvds.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Helpers;
using Phoenix.Services.Mappings;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Rvds.Queries
{
   internal sealed class GetRvd145ChartHandler : HandlerBase, IRequestHandler<GetRvd145ChartQuery, IReadOnlyCollection<Rvd145ChartDto>>
   {
      public GetRvd145ChartHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<Rvd145ChartDto>> Handle(GetRvd145ChartQuery request, CancellationToken cancellationToken)
      {
         return await PlcHandlerHelper
            .GetPlcChartQuery(_uow.Rvd145, request)
            .Select(x => x.ToRvd145ChartDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
