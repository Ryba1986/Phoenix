using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Shared.Controllers;
using Phoenix.Api.Web.Attributes;
using Phoenix.Models.Reports.Queries;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Api.Web.Controllers
{
   public sealed class ReportController : ApiControllerBase
   {
      public ReportController(IMediator mediator) : base(mediator)
      {
      }

      [HttpGet]
      public async Task<IActionResult> GetPlcReportTypeDictionary()
      {
         return await HandleAsync(new GetPlcReportTypeDictionaryQuery());
      }

      [Authorization(Permission.Report, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetPlcReport([FromQuery] GetPlcReportQuery request)
      {
         return await HandleAsync(request);
      }
   }
}
