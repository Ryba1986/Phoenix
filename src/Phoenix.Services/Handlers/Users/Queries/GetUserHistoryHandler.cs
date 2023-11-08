using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Users.Dto;
using Phoenix.Models.Users.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Mappings;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Users.Queries
{
   internal sealed class GetUserHistoryHandler : HandlerBase, IRequestHandler<GetUserHistoryQuery, IReadOnlyCollection<UserHistoryDto>>
   {
      public GetUserHistoryHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<UserHistoryDto>> Handle(GetUserHistoryQuery request, CancellationToken cancellationToken)
      {
         return await _uow.UserHistory
            .AsNoTracking()
            .Include(x => x.Role)
            .Include(x => x.CreatedBy)
            .Where(x => x.UserId == request.UserId)
            .OrderByDescending(x => x.CreateDate)
            .Select(x => x.ToUserHistoryDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
