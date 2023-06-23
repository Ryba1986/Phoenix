using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
         IReadOnlyCollection<RolePermissionDto> result = await _uow.RolePermission
            .AsNoTracking()
            .Where(x => x.RoleId == request.RoleId)
            .ProjectTo<RolePermissionDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);

         return result
            .OrderBy(x => x.Permission.GetDescription())
            .ToArray();
      }
   }
}
