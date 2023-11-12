using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Models.Plcs.Climatixs.Dto;
using Phoenix.Models.Plcs.Climatixs.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Helpers;
using Phoenix.Services.Mappings;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Climatixs.Queries
{
   internal sealed class GetClimatixLastHandler : HandlerBase, IRequestHandler<GetClimatixLastQuery, ClimatixDto?>
   {
      public GetClimatixLastHandler(UnitOfWork uow) : base(uow)
      {
      }

      public Task<ClimatixDto?> Handle(GetClimatixLastQuery request, CancellationToken cancellationToken)
      {
         return PlcHandlerHelper.GetPlcLastAsync(_uow.Climatix, request, x => x.ToClimatixDto(), cancellationToken);
      }
   }
}
