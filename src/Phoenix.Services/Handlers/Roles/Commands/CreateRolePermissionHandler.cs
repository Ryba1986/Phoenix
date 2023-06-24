using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Roles;
using Phoenix.Models.Roles.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Languages;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Roles.Commands
{
   internal sealed class CreateRolePermissionHandler : HandlerBase, IRequestHandler<CreateRolePermissionCommand, Result>
   {
      public CreateRolePermissionHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(CreateRolePermissionCommand request, CancellationToken cancellationToken)
      {
         if (!await IsActiveUserExistsAsync(request.CreatedById, cancellationToken))
         {
            return Result.Error(Translations.User_Active_NotExists);
         }

         bool roleExists = await _uow.Role
            .AsNoTracking()
            .AnyAsync(x => x.Id == request.RoleId, cancellationToken);

         if (!roleExists)
         {
            return Result.Error(Translations.Role_NotExists);
         }

         bool permissionExists = await _uow.RolePermission
            .AsNoTracking()
            .AnyAsync(x =>
               x.RoleId == request.RoleId &&
               x.Permission == request.Permission
            , cancellationToken);

         if (permissionExists)
         {
            return Result.Error(Translations.RolePermission_Exists);
         }

         RolePermission newRolePermission = new()
         {
            RoleId = request.RoleId,
            Permission = request.Permission,
            AccessLevel = request.AccessLevel,
            IsActive = true,
         };

         _uow.RolePermission.Add(newRolePermission);

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
