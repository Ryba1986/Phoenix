using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Roles;
using Phoenix.Entities.Users;
using Phoenix.Models.Users.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Languages;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Users.Commands
{
   internal sealed class UpdateUserHandler : HandlerBase, IRequestHandler<UpdateUserCommand, Result>
   {
      public UpdateUserHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
      {
         if (!await IsActiveUserExistsAsync(request.ModifiedById, cancellationToken))
         {
            return Result.Error(Translations.User_Active_NotExists);
         }

         bool otherExists = await _uow.User
            .AsNoTracking()
            .AnyAsync(x =>
               x.Email == request.Email &&
               x.Id != request.Id
            , cancellationToken);

         if (otherExists)
         {
            return Result.Error(Translations.User_Exists);
         }

         Role? role = await _uow.Role
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.RoleId, cancellationToken);

         if (role is null)
         {
            return Result.Error(Translations.Role_NotExists);
         }

         User? user = await _uow.User.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
         if (user is null)
         {
            return Result.Error(Translations.User_NotExists);
         }
         if (!user.Version.SequenceEqual(request.Version))
         {
            return Result.Error(Translations.Validator_Version_Invalid);
         }

         user.Update(request.Name, request.Email, role.Id, request.IsActive);

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
