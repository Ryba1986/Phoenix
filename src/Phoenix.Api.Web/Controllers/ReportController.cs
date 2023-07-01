using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Api.Web.Attributes;
using Phoenix.Api.Web.Controllers.Base;
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
      public async Task<IActionResult> GetReportTypeDictionary()
      {
         return await HandleAsync(new GetReportTypeDictionaryQuery());
      }

      [Authorization(Permission.Report, AccessLevel.Read)]
      [HttpGet]
      public async Task<IActionResult> GetReport([FromQuery] GetReportQuery request)
      {
         return await HandleAsync(request);
      }
   }
}
