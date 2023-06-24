using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Web.Attributes;
using Phoenix.Api.Web.Controllers.Base;
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

      [HttpGet]
      [Authorization(Permission.Location, AccessLevel.Read)]
      public async Task<IActionResult> GetLocations()
      {
         return await HandleAsync(new GetLocationsQuery());
      }

      [HttpGet]
      [Authorization(Permission.Location, AccessLevel.Read)]
      public async Task<IActionResult> GetLocationHistory([FromQuery] GetLocationHistoryQuery request)
      {
         return await HandleAsync(request);
      }

      [HttpGet]
      public async Task<IActionResult> GetLocationDictionary()
      {
         return await HandleAsync(new GetLocationDictionaryQuery());
      }

      [HttpPost]
      [Authorization(Permission.Location, AccessLevel.Write)]
      public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand request)
      {
         return await HandleAsync(request);
      }

      [HttpPost]
      [Authorization(Permission.Location, AccessLevel.Write)]
      public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationCommand request)
      {
         return await HandleAsync(request);
      }
   }
}
