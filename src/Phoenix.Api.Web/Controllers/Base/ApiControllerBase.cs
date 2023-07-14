using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Models.Base.Commands;
using Phoenix.Shared.Extensions;
using Phoenix.Shared.Results;

namespace Phoenix.Api.Web.Controllers.Base
{
   [Authorize]
   [Route("[controller]/[action]")]
   public abstract class ApiControllerBase : ControllerBase
   {
      private readonly IMediator _mediator;

      public ApiControllerBase(IMediator mediator)
      {
         _mediator = mediator;
      }

      protected int GetId()
      {
         return User.Claims.GetId();
      }

      protected async Task<IActionResult> HandleAsync<T>(IRequest<T?> request)
      {
         return Ok(await _mediator.Send(request));
      }

      protected async Task<IActionResult> HandleAsync(CommandBase request)
      {
         request.SetId(GetId());

         return ModelState.IsValid
            ? Ok(await _mediator.Send(request))
            : Ok(Result.Error(ModelState.Values.First().Errors.First().ErrorMessage));
      }
   }
}
