using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Shared.Controllers;
using Phoenix.Api.Web.Attributes;
using Phoenix.Models.Plcs.Rvds.Queries;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Api.Web.Controllers
{
   public sealed class Rvd145Controller : ApiControllerBase
   {
      public Rvd145Controller(IMediator mediator) : base(mediator)
      {
      }

      [Authorization(Permission.Plc, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetRvd145ChartDay([FromQuery] GetRvd145ChartDayQuery request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.Plc, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetRvd145Last([FromQuery] GetRvd145LastQuery request)
      {
         return await HandleAsync(request);
      }
   }
}
