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
   internal sealed class UpdateRolePermissionHandler : HandlerBase, IRequestHandler<UpdateRolePermissionCommand, Result>
   {
      public UpdateRolePermissionHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(UpdateRolePermissionCommand request, CancellationToken cancellationToken)
      {
         if (!await IsActiveUserExistsAsync(request.ModifiedById, cancellationToken))
         {
            return Result.Error(Translations.User_Active_NotExists);
         }

         RolePermission? rolePermission = await _uow.RolePermission.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
         if (rolePermission is null)
         {
            return Result.Error(Translations.RolePermission_NotExists);
         }
         if (rolePermission.Version != request.Version)
         {
            return Result.Error(Translations.Validator_Version_Invalid);
         }

         rolePermission.AccessLevel = request.AccessLevel;

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
