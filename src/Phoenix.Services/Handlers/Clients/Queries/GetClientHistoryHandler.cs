using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Clients.Dto;
using Phoenix.Models.Clients.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Mappings;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Clients.Queries
{
   internal sealed class GetClientHistoryHandler : HandlerBase, IRequestHandler<GetClientHistoryQuery, IReadOnlyCollection<ClientHistoryDto>>
   {
      public GetClientHistoryHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<ClientHistoryDto>> Handle(GetClientHistoryQuery request, CancellationToken cancellationToken)
      {
         return await _uow.ClientHistory
            .AsNoTracking()
            .Include(x => x.Location)
            .Include(x => x.CreatedBy)
            .Where(x => x.ClientId == request.ClientId)
            .OrderByDescending(x => x.CreateDate)
            .Select(x => x.ToClientHistoryDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
