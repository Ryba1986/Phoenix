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
   internal sealed class GetClimatixLastHandler : QueryHandlerBase, IRequestHandler<GetClimatixLastQuery, ClimatixDto?>
   {
      public GetClimatixLastHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public Task<ClimatixDto?> Handle(GetClimatixLastQuery request, CancellationToken cancellationToken)
      {
         return GetPlcLastAsync<Climatix, ClimatixDto>(_uow.Climatix, request, cancellationToken);
      }
   }
}
