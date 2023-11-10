using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Shared.Controllers;
using Phoenix.Api.Web.Attributes;
using Phoenix.Models.Devices.Commands;
using Phoenix.Models.Devices.Queries;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Api.Web.Controllers
{
   public sealed class DeviceController : ApiControllerBase
   {
      public DeviceController(IMediator mediator) : base(mediator)
      {
      }

      [Authorization(Permission.Device, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetDevices([FromQuery] GetDevicesQuery request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.Device, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetDevicesByLocation([FromQuery] GetDevicesByLocationQuery request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.Device, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetDeviceHistory([FromQuery] GetDeviceHistoryQuery request)
      {
         return await HandleAsync(request);
      }

      [HttpGet]
      public async Task<IActionResult> GetDevicePlcTypeDictionary()
      {
         return await HandleAsync(new GetDevicePlcTypeDictionaryQuery());
      }

      [HttpGet]
      public async Task<IActionResult> GetDeviceBoundRateDictionary()
      {
         return await HandleAsync(new GetDeviceBoundRateDictionaryQuery());
      }

      [HttpGet]
      public async Task<IActionResult> GetDeviceDataBitDictionary()
      {
         return await HandleAsync(new GetDeviceDataBitDictionaryQuery());
      }

      [HttpGet]
      public async Task<IActionResult> GetDeviceParityDictionary()
      {
         return await HandleAsync(new GetDeviceParityDictionaryQuery());
      }

      [HttpGet]
      public async Task<IActionResult> GetDeviceStopBitDictionary()
      {
         return await HandleAsync(new GetDeviceStopBitDictionaryQuery());
      }

      [Authorization(Permission.Device, AccessLevel.Write)]
      [HttpPost]
      public async Task<IActionResult> CreateDevice([FromBody] CreateDeviceCommand request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.Device, AccessLevel.Write)]
      [HttpPost]
      public async Task<IActionResult> UpdateDevice([FromBody] UpdateDeviceCommand request)
      {
         return await HandleAsync(request);
      }
   }
}
