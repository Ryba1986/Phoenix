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
   internal sealed class GetClimatixLastHandler : HandlerBase, IRequestHandler<GetClimatixLastQuery, ClimatixDto?>
   {
      public GetClimatixLastHandler(UnitOfWork uow) : base(uow)
      {
      }

      public Task<ClimatixDto?> Handle(GetClimatixLastQuery request, CancellationToken cancellationToken)
      {
         return PlcHandlerHelper
            .GetPlcLastQuery(_uow.Climatix, request)
            .Select(x => x.ToClimatixDto())
            .FirstOrDefaultAsync(cancellationToken);
      }
   }
}
