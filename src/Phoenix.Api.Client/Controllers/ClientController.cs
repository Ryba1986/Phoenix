using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Client.Controllers.Base;
using Phoenix.Models.Clients.Commands;
using Phoenix.Models.Clients.Queries;

namespace Phoenix.Api.Client.Controllers
{
   public sealed class ClientController : ApiControllerBase
   {
      public ClientController(IMediator mediator) : base(mediator)
      {
      }

      [AllowAnonymous]
      [HttpPost]
      public async Task<IActionResult> GetClientToken([FromBody] GetClientTokenQuery request)
      {
         return await HandleAsync(request);
      }

      [HttpPost]
      public async Task<IActionResult> GetClientTokenRefresh()
      {
         return await HandleAsync(new GetClientTokenRefreshQuery()
         {
            ClientId = GetId(),
         });
      }

      [HttpPost]
      public async Task<IActionResult> UpdateClientInfo([FromBody] UpdateClientInfoCommand request)
      {
         return await HandleAsync(request);
      }
   }
}
