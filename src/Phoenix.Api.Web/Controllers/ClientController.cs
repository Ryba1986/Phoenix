using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Web.Attributes;
using Phoenix.Api.Web.Controllers.Base;
using Phoenix.Models.Clients.Commands;
using Phoenix.Models.Clients.Queries;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Api.Web.Controllers
{
   public sealed class ClientController : ApiControllerBase
   {
      public ClientController(IMediator mediator) : base(mediator)
      {
      }

      [Authorization(Permission.Client, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetClients()
      {
         return await HandleAsync(new GetClientsQuery());
      }

      [Authorization(Permission.Client, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetClientHistory([FromQuery] GetClientHistoryQuery request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.Client, AccessLevel.Write)]
      [HttpPost]
      public async Task<IActionResult> CreateClient([FromBody] CreateClientCommand request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.Client, AccessLevel.Write)]
      [HttpPost]
      public async Task<IActionResult> UpdateClient([FromBody] UpdateClientCommand request)
      {
         return await HandleAsync(request);
      }
   }
}
