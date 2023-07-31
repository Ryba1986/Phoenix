using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Roles;
using Phoenix.Models.Roles.Dto;
using Phoenix.Models.Roles.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Extensions;

namespace Phoenix.Services.Handlers.Roles.Queries
{
   internal sealed class GetRolePermissionsHandler : QueryHandlerBase, IRequestHandler<GetRolePermissionsQuery, IReadOnlyCollection<RolePermissionDto>>
   {
      public GetRolePermissionsHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<IReadOnlyCollection<RolePermissionDto>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
      {
         IReadOnlyCollection<RolePermission> result = await _uow.RolePermission
            .AsNoTracking()
            .Include(x => x.Role)
            .ToArrayAsync(cancellationToken);

         result = result
            .OrderBy(x => x.Role.Name)
            .ThenBy(x => x.Permission.GetDescription())
            .ToArray();

         return _mapper.Map<IReadOnlyCollection<RolePermissionDto>>(result);
      }
   }
}
