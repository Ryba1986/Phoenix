using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Phoenix.Entities.Plcs.Rvds;
using Phoenix.Models.Plcs.Rvds.Dto;
using Phoenix.Models.Plcs.Rvds.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Rvds.Queries
{
   internal sealed class GetRvd145ChartHandler : QueryHandlerBase, IRequestHandler<GetRvd145ChartQuery, IReadOnlyCollection<Rvd145ChartDto>>
   {
      public GetRvd145ChartHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public Task<IReadOnlyCollection<Rvd145ChartDto>> Handle(GetRvd145ChartQuery request, CancellationToken cancellationToken)
      {
         return GetPlcChartAsync<Rvd145, Rvd145ChartDto>(_uow.Rvd145, request, cancellationToken);
      }
   }
}
