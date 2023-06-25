using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Web.Attributes;
using Phoenix.Api.Web.Controllers.Base;
using Phoenix.Models.Roles.Commands;
using Phoenix.Models.Roles.Queries;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Api.Web.Controllers
{
   public sealed class RoleController : ApiControllerBase
   {
      public RoleController(IMediator mediator) : base(mediator)
      {
      }

      [Authorization(Permission.Role, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetRoles()
      {
         return await HandleAsync(new GetRolesQuery());
      }

      [Authorization(Permission.Role, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetRoleHistory([FromQuery] GetRoleHistoryQuery request)
      {
         return await HandleAsync(request);
      }

      [HttpGet]
      public async Task<IActionResult> GetRoleDictionary()
      {
         return await HandleAsync(new GetRoleDictionaryQuery());
      }

      [Authorization(Permission.Role, AccessLevel.Write)]
      [HttpPost]
      public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.Role, AccessLevel.Write)]
      [HttpPost]
      public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand request)
      {
         return await HandleAsync(request);
      }
   }
}
