using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Shared.Controllers;
using Phoenix.Api.Web.Attributes;
using Phoenix.Models.Plcs.Meters.Queries;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Api.Web.Controllers
{
   public sealed class KamstrupController : ApiControllerBase
   {
      public KamstrupController(IMediator mediator) : base(mediator)
      {
      }

      [Authorization(Permission.Plc, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetKamstrupChart([FromQuery] GetKamstrupChartQuery request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.Plc, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetKamstrupLast([FromQuery] GetKamstrupLastQuery request)
      {
         return await HandleAsync(request);
      }
   }
}
