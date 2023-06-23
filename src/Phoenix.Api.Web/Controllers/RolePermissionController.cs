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

      [HttpGet]
      [Authorization(Permission.Role, AccessLevel.Read)]
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

      [HttpPost]
      [Authorization(Permission.Role, AccessLevel.Write)]
      public async Task<IActionResult> CreateRolePermission([FromBody] CreateRolePermissionCommand request)
      {
         return await HandleAsync(request);
      }

      [HttpPost]
      [Authorization(Permission.Role, AccessLevel.Write)]
      public async Task<IActionResult> UpdateRolePermission([FromBody] UpdateRolePermissionCommand request)
      {
         return await HandleAsync(request);
      }
   }
}
