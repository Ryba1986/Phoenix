using System.Collections.Generic;
using MediatR;
using Phoenix.Models.Roles.Dto;

namespace Phoenix.Models.Roles.Queries
{
   public sealed class GetRolePermissionsQuery : IRequest<IReadOnlyCollection<RolePermissionDto>>
   {
      public int RoleId { get; init; }
   }
}
