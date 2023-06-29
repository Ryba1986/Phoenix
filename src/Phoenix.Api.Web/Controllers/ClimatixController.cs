using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Web.Attributes;
using Phoenix.Api.Web.Controllers.Base;
using Phoenix.Models.Plcs.Climatixs.Queries;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Api.Web.Controllers
{
   public sealed class ClimatixController : ApiControllerBase
   {
      public ClimatixController(IMediator mediator) : base(mediator)
      {
      }

      [Authorization(Permission.Plc, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetClimatixChart([FromQuery] GetClimatixChartQuery request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.Plc, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetClimatixLast([FromQuery] GetClimatixLastQuery request)
      {
         return await HandleAsync(request);
      }
   }
}
