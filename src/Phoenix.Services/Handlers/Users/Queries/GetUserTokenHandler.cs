using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Roles;
using Phoenix.Entities.Users;
using Phoenix.Models.Users.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Helpers;
using Phoenix.Services.Repositories;
using Phoenix.Services.Settings;
using Phoenix.Shared.Extensions;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Users.Queries
{
   internal sealed class GetUserTokenHandler : HandlerBase, IRequestHandler<GetUserTokenQuery, TokenResult>
   {
      private readonly JwtSettings _settings;

      public GetUserTokenHandler(UnitOfWork uow, JwtSettings settings) : base(uow)
      {
         _settings = settings;
      }

      public async Task<TokenResult> Handle(GetUserTokenQuery request, CancellationToken cancellationToken)
      {
         User? user = await _uow.User
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
               x.Email == request.Email &&
               x.Password == request.Password.CreatePassword() &&
               x.IsActive
            , cancellationToken);

         if (user is null)
         {
            return new();
         }

         Role? role = await _uow.Role
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
               x.Id == user.RoleId &&
               x.IsActive
            , cancellationToken);

         if (role is null)
         {
            return new();
         }

         IReadOnlyCollection<RolePermission> permissions = await _uow.RolePermission
            .AsNoTracking()
            .Where(x =>
               x.RoleId == role.Id &&
               x.IsActive
            )
            .ToArrayAsync(cancellationToken);

         if (permissions.Count == 0)
         {
            return new();
         }

         return JwtHandlerHelper.CreateWeb(user, permissions, _settings);
      }
   }
}
