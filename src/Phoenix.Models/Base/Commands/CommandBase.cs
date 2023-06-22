using MediatR;
using Phoenix.Shared.Results;

namespace Phoenix.Models.Base.Commands
{
   public abstract class CommandBase : IRequest<Result>
   {
      public abstract void SetId(int id);
   }
}
