using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Roles;
using Phoenix.Models.Roles.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Helpers;
using Phoenix.Shared.Languages;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Roles.Commands
{
   internal sealed class UpdateRoleHandler : HandlerBase, IRequestHandler<UpdateRoleCommand, Result>
   {
      public UpdateRoleHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
      {
         if (!await IsActiveUserExistsAsync(request.ModifiedById, cancellationToken))
         {
            return Result.Error(Translations.User_Active_NotExists);
         }

         bool otherExists = await _uow.Role
            .AsNoTracking()
            .AnyAsync(x =>
               x.Name == request.Name &&
               x.Id != request.Id
            , cancellationToken);

         if (otherExists)
         {
            return Result.Error(Translations.Role_Exists);
         }

         Role? role = await _uow.Role.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
         if (role is null)
         {
            return Result.Error(Translations.Role_NotExists);
         }
         if (role.Version != request.Version)
         {
            return Result.Error(Translations.Validator_Version_Invalid);
         }
         if (role.Name == request.Name && role.IsAdmin == request.IsAdmin && role.IsActive == request.IsActive)
         {
            return Result.Success();
         }

         _uow.RoleHistory.Add(new()
         {
            RoleId = request.Id,
            Name = role.Name != request.Name ? request.Name : string.Empty,
            IsAdmin = request.IsAdmin,
            IsActive = request.IsActive,
            CreatedById = request.ModifiedById,
            CreateDate = await GetServerDateAsync(),
         });

         role.Name = request.Name;
         role.IsAdmin = request.IsAdmin;
         role.IsActive = request.IsActive;
         role.Version = RandomHelper.NewShort();

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
