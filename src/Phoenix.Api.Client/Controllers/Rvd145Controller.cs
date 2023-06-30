using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Client.Controllers.Base;
using Phoenix.Models.Plcs.Rvds.Commands;

namespace Phoenix.Api.Client.Controllers
{
   public sealed class Rvd145Controller : ApiControllerBase
   {
      public Rvd145Controller(IMediator mediator) : base(mediator)
      {
      }

      [HttpPost]
      public async Task<IActionResult> CreateRvd145([FromBody] CreateRvd145Command request)
      {
         return await HandleAsync(request);
      }
   }
}
