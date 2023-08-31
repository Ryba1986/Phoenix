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

         bool roleExists = await _uow.Role
            .AsNoTracking()
            .AnyAsync(x => x.Id == request.RoleId, cancellationToken);

         if (!roleExists)
         {
            return Result.Error(Translations.Role_NotExists);
         }

         // TODO: generate random password and send an email
         User newUser = new()
         {
            Name = request.Name,
            Email = request.Email,
            Password = request.Email.CreatePassword(),
            RoleId = request.RoleId,
            IsActive = request.IsActive,
         };

         _uow.User.Add(newUser);
         _uow.UserHistory.Add(new()
         {
            User = newUser,
            RoleId = request.RoleId,
            Name = request.Name,
            Email = request.Email,
            IsActive = request.IsActive,
            CreatedById = request.CreatedById,
            CreateDate = await GetServerDateAsync(),
         });

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
