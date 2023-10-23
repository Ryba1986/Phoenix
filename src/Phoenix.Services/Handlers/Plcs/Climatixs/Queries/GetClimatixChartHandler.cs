using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

      public async Task<IReadOnlyCollection<ClimatixChartDto>> Handle(GetClimatixChartQuery request, CancellationToken cancellationToken)
      {
         return await PlcHandlerHelper
            .GetPlcChartQuery(_uow.Climatix, request)
            .Select(x => x.ToClimatixChartDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
