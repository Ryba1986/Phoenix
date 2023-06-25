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
   public sealed class RolePermissionController : ApiControllerBase
   {
      public RolePermissionController(IMediator mediator) : base(mediator)
      {
      }

      [Authorization(Permission.Role, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetRolePermissions([FromQuery] GetRolePermissionsQuery request)
      {
         return await HandleAsync(request);
      }

      [HttpGet]
      public async Task<IActionResult> GetAccessLevelDictionary()
      {
         return await HandleAsync(new GetAccessLevelDictionaryQuery());
      }

      [HttpGet]
      public async Task<IActionResult> GetPermissionDictionary()
      {
         return await HandleAsync(new GetPermissionDictionaryQuery());
      }

      [Authorization(Permission.Role, AccessLevel.Write)]
      [HttpPost]
      public async Task<IActionResult> CreateRolePermission([FromBody] CreateRolePermissionCommand request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.Role, AccessLevel.Write)]
      [HttpPost]
      public async Task<IActionResult> UpdateRolePermission([FromBody] UpdateRolePermissionCommand request)
      {
         return await HandleAsync(request);
      }
   }
}
