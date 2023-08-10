using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Phoenix.Entities.Plcs.Climatixs;
using Phoenix.Models.Plcs.Climatixs.Dto;
using Phoenix.Models.Plcs.Climatixs.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Climatixs.Queries
{
   internal sealed class GetClimatixChartHandler : QueryHandlerBase, IRequestHandler<GetClimatixChartQuery, IReadOnlyCollection<ClimatixChartDto>>
   {
      public GetClimatixChartHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public Task<IReadOnlyCollection<ClimatixChartDto>> Handle(GetClimatixChartQuery request, CancellationToken cancellationToken)
      {
         return GetPlcChartAsync<Climatix, ClimatixChartDto>(_uow.Climatix, request, cancellationToken);
      }
   }
}
