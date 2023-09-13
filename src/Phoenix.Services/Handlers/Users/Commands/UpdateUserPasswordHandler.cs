using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Users;
using Phoenix.Models.Users.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Extensions;
using Phoenix.Shared.Languages;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Users.Commands
{
   internal sealed class UpdateUserPasswordHandler : HandlerBase, IRequestHandler<UpdateUserPasswordCommand, Result>
   {
      public UpdateUserPasswordHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
      {
         User? user = await _uow.User
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
               x.Id == request.UserId &&
               x.Password == request.CurrentPassword.CreatePassword() &&
               x.IsActive
         , cancellationToken);

         if (user is null)
         {
            return Result.Error(Translations.User_NotExists);
         }

         user.Password = request.NewPassword.CreatePassword();

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
