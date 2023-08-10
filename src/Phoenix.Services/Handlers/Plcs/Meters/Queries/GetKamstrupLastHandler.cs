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
   internal sealed class GetKamstrupLastHandler : QueryHandlerBase, IRequestHandler<GetKamstrupLastQuery, KamstrupDto?>
   {
      public GetKamstrupLastHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public Task<KamstrupDto?> Handle(GetKamstrupLastQuery request, CancellationToken cancellationToken)
      {
         return GetPlcLastAsync<Kamstrup, KamstrupDto>(_uow.Kamstrup, request, cancellationToken);
      }
   }
}
