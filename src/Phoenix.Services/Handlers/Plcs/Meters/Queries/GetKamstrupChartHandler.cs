using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Phoenix.Entities.Plcs.Meters;
using Phoenix.Models.Plcs.Meters.Dto;
using Phoenix.Models.Plcs.Meters.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Meters.Queries
{
   internal sealed class GetKamstrupChartHandler : QueryHandlerBase, IRequestHandler<GetKamstrupChartQuery, IReadOnlyCollection<KamstrupChartDto>>
   {
      public GetKamstrupChartHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public Task<IReadOnlyCollection<KamstrupChartDto>> Handle(GetKamstrupChartQuery request, CancellationToken cancellationToken)
      {
         return GetPlcChartAsync<Kamstrup, KamstrupChartDto>(_uow.Kamstrup, request, cancellationToken);
      }
   }
}
