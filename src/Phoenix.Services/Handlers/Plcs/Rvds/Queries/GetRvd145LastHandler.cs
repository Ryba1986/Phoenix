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
   internal sealed class GetRvd145LastHandler : QueryHandlerBase, IRequestHandler<GetRvd145LastQuery, Rvd145Dto?>
   {
      public GetRvd145LastHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public Task<Rvd145Dto?> Handle(GetRvd145LastQuery request, CancellationToken cancellationToken)
      {
         return GetPlcLastAsync<Rvd145, Rvd145Dto>(_uow.Rvd145, request, cancellationToken);
      }
   }
}
