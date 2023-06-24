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
   internal sealed class CreateUserHandler : HandlerBase, IRequestHandler<CreateUserCommand, Result>
   {
      public CreateUserHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
      {
         if (!await IsActiveUserExistsAsync(request.CreatedById, cancellationToken))
         {
            return Result.Error(Translations.User_Active_NotExists);
         }

         bool userExists = await _uow.User
            .AsNoTracking()
            .AnyAsync(x => x.Email == request.Email, cancellationToken);

         if (userExists)
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

         // TODO: generate random password and send an email
         User newUser = new(request.Name, request.Email, request.Email, role.Id, request.IsActive);

         _uow.Add(newUser);

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
