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
   internal sealed class GetRolePermissionsHandler : HandlerBase, IRequestHandler<GetRolePermissionsQuery, IReadOnlyCollection<RolePermissionDto>>
   {
      public GetRolePermissionsHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<RolePermissionDto>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
      {
         return await _uow.RolePermission
            .AsNoTracking()
            .Where(x => x.RoleId == request.RoleId)
            .OrderBy(x => x.Permission)
            .Select(x => x.ToRolePermissionDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
