using System.Collections.Generic;
using MediatR;
using Phoenix.Models.Roles.Dto;

namespace Phoenix.Models.Roles.Queries
{
   public sealed class GetRoleHistoryQuery : IRequest<IReadOnlyCollection<RoleHistoryDto>>
   {
      public int RoleId { get; init; }
   }
}
