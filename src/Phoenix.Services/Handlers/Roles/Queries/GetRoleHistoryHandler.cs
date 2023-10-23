using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Roles.Dto;
using Phoenix.Models.Roles.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Mappings;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Roles.Queries
{
   internal sealed class GetRoleHistoryHandler : HandlerBase, IRequestHandler<GetRoleHistoryQuery, IReadOnlyCollection<RoleHistoryDto>>
   {
      public GetRoleHistoryHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<RoleHistoryDto>> Handle(GetRoleHistoryQuery request, CancellationToken cancellationToken)
      {
         return await _uow.RoleHistory
            .AsNoTracking()
            .Include(x => x.CreatedBy)
            .Where(x => x.RoleId == request.RoleId)
            .Select(x => x.ToRoleHistoryDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
