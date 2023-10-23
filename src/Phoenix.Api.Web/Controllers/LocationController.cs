using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Shared.Controllers;
using Phoenix.Api.Web.Attributes;
using Phoenix.Models.Locations.Commands;
using Phoenix.Models.Locations.Queries;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Api.Web.Controllers
{
   public sealed class LocationController : ApiControllerBase
   {
      public LocationController(IMediator mediator) : base(mediator)
      {
      }

      [Authorization(Permission.Location, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetLocations([FromQuery] GetLocationsQuery request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.Location, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetLocationHistory([FromQuery] GetLocationHistoryQuery request)
      {
         return await HandleAsync(request);
      }

      [HttpGet]
      public async Task<IActionResult> GetLocationDictionary([FromQuery] GetLocationDictionaryQuery request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.Location, AccessLevel.Write)]
      [HttpPost]
      public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand request)
      {
         return await HandleAsync(request);
      }

      [Authorization(Permission.Location, AccessLevel.Write)]
      [HttpPost]
      public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationCommand request)
      {
         return await HandleAsync(request);
      }
   }
}
