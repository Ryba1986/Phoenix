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
   internal sealed class CreateRoleHandler : HandlerBase, IRequestHandler<CreateRoleCommand, Result>
   {
      public CreateRoleHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
      {
         if (!await IsActiveUserExistsAsync(request.CreatedById, cancellationToken))
         {
            return Result.Error(Translations.User_Active_NotExists);
         }

         bool roleExists = await _uow.Role
            .AsNoTracking()
            .AnyAsync(x => x.Name == request.Name, cancellationToken);

         if (roleExists)
         {
            return Result.Error(Translations.Role_Exists);
         }

         Role newRole = new()
         {
            Name = request.Name,
            IsAdmin = request.IsAdmin,
            IsActive = request.IsActive,
         };

         _uow.Role.Add(newRole);
         _uow.RoleHistory.Add(new()
         {
            Role = newRole,
            Name = request.Name,
            IsAdmin = request.IsAdmin,
            IsActive = request.IsActive,
            CreatedById = request.CreatedById,
         });

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
