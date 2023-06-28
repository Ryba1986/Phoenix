using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Client.Controllers.Base;
using Phoenix.Models.Plcs.Meters.Commands;

namespace Phoenix.Api.Client.Controllers
{
   public sealed class KamstrupController : ApiControllerBase
   {
      public KamstrupController(IMediator mediator) : base(mediator)
      {
      }

      [HttpPost]
      public async Task<IActionResult> CreateKamstrup([FromBody] CreateKamstrupCommand request)
      {
         return await HandleAsync(request);
      }
   }
}
