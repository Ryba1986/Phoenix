using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Web.Attributes;
using Phoenix.Api.Web.Controllers.Base;
using Phoenix.Models.Users.Commands;
using Phoenix.Models.Users.Queries;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Api.Web.Controllers
{
   public sealed class UserController : ApiControllerBase
   {
      public UserController(IMediator mediator) : base(mediator)
      {
      }

      [Authorization(Permission.User, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetUsers()
      {
         return await HandleAsync(new GetUsersQuery());
      }

      [Authorization(Permission.User, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetUserHistory([FromQuery] GetUserHistoryQuery request)
      {
         return await HandleAsync(request);
      }

      [HttpGet]
      public async Task<IActionResult> GetUserDictionary()
      {
         return await HandleAsync(new GetUserDictionaryQuery());
      }

      [AllowAnonymous]
      [HttpPost]
      public async Task<IActionResult> GetUserToken([FromBody] GetUserTokenQuery request)
      {
         return await HandleAsync(request);
      }

      [HttpPost]
      public async Task<IActionResult> GetUserTokenRefresh()
      {
         return await HandleAsync(new GetUserTokenRefreshQuery()
         {
            UserId = GetId(),
         });
      }

      [Authorization(Permission.User, AccessLevel.Write)]
      [HttpPost]
      public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.User, AccessLevel.Write)]
      [HttpPost]
      public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand request)
      {
         return await HandleAsync(request);
      }

      [HttpPost]
      public async Task<IActionResult> UpdateUserPassword([FromBody] UpdateUserPasswordCommand request)
      {
         return await HandleAsync(request);
      }
   }
}
