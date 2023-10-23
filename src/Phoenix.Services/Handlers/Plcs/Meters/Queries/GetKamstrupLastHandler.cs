using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Plcs.Meters.Dto;
using Phoenix.Models.Plcs.Meters.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Helpers;
using Phoenix.Services.Mappings;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Meters.Queries
{
   internal sealed class GetKamstrupLastHandler : HandlerBase, IRequestHandler<GetKamstrupLastQuery, KamstrupDto?>
   {
      public GetKamstrupLastHandler(UnitOfWork uow) : base(uow)
      {
      }

      public Task<KamstrupDto?> Handle(GetKamstrupLastQuery request, CancellationToken cancellationToken)
      {
         return PlcHandlerHelper
            .GetPlcLastQuery(_uow.Kamstrup, request)
            .Select(x => x.ToKamstrupDto())
            .FirstOrDefaultAsync(cancellationToken);
      }
   }
}
