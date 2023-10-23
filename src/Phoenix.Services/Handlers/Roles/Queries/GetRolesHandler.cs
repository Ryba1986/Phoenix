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
   internal sealed class GetRolesHandler : HandlerBase, IRequestHandler<GetRolesQuery, IReadOnlyCollection<RoleDto>>
   {
      public GetRolesHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
      {
         return await _uow.Role
            .AsNoTracking()
            .Select(x => x.ToRoleDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
