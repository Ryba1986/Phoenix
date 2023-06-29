using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Client.Controllers.Base;
using Phoenix.Models.Plcs.Climatixs.Commands;

namespace Phoenix.Api.Client.Controllers
{
   public sealed class ClimatixController : ApiControllerBase
   {
      public ClimatixController(IMediator mediator) : base(mediator)
      {
      }

      [HttpPost]
      public async Task<IActionResult> CreateClimatix([FromBody] CreateClimatixCommand request)
      {
         return await HandleAsync(request);
      }
   }
}
