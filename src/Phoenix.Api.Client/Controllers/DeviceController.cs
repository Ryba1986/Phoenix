using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Client.Controllers.Base;
using Phoenix.Models.Devices.Queries;

namespace Phoenix.Api.Client.Controllers
{
   public sealed class DeviceController : ApiControllerBase
   {
      public DeviceController(IMediator mediator) : base(mediator)
      {
      }

      [HttpGet]
      public async Task<IActionResult> GetDevicesByClient([FromQuery] GetDevicesByClientQuery request)
      {
         return await HandleAsync(request);
      }
   }
}
