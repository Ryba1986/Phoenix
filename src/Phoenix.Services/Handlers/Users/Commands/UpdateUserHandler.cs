using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
         if (!await IsActiveUserAsync(request.ModifiedById, cancellationToken))
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

         bool roleExists = await _uow.Role
            .AsNoTracking()
            .AnyAsync(x => x.Id == request.RoleId, cancellationToken);

         if (!roleExists)
         {
            return Result.Error(Translations.Role_NotExists);
         }

         User? user = await _uow.User.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
         if (user is null)
         {
            return Result.Error(Translations.User_NotExists);
         }
         if (user.Version != request.Version)
         {
            return Result.Error(Translations.Validator_Version_Invalid);
         }
         if (user.Name == request.Name && user.Email == request.Email && user.RoleId == request.RoleId && user.IsActive == request.IsActive)
         {
            return Result.Success();
         }

         _uow.UserHistory.Add(new()
         {
            UserId = request.Id,
            RoleId = user.RoleId != request.RoleId ? request.RoleId : null,
            Name = user.Name != request.Name ? request.Name : string.Empty,
            Email = user.Email != request.Email ? request.Email : string.Empty,
            IsActive = request.IsActive,
            CreatedById = request.ModifiedById,
            CreateDate = GetServerDate(),
         });

         user.RoleId = request.RoleId;
         user.Name = request.Name;
         user.Email = request.Email;
         user.IsActive = request.IsActive;

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
