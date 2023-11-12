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
   internal sealed class GetRvd145LastHandler : HandlerBase, IRequestHandler<GetRvd145LastQuery, Rvd145Dto?>
   {
      public GetRvd145LastHandler(UnitOfWork uow) : base(uow)
      {
      }

      public Task<Rvd145Dto?> Handle(GetRvd145LastQuery request, CancellationToken cancellationToken)
      {
         return PlcHandlerHelper.GetPlcLastAsync(_uow.Rvd145, request.DeviceId, x => x.ToRvd145Dto(), cancellationToken);
      }
   }
}
