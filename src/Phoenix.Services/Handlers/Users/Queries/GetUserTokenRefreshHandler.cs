using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
   internal sealed class GetUserTokenRefreshHandler : HandlerBase, IRequestHandler<GetUserTokenRefreshQuery, TokenResult>
   {
      private readonly JwtSettings _settings;

      public GetUserTokenRefreshHandler(UnitOfWork uow, JwtSettings settings) : base(uow)
      {
         _settings = settings;
      }

      public async Task<TokenResult> Handle(GetUserTokenRefreshQuery request, CancellationToken cancellationToken)
      {
         User? user = await _uow.User
            .AsNoTracking()
            .Include(x => x.Role)
            .ThenInclude(x => x.Permissions)
            .FirstOrDefaultAsync(x =>
               x.Id == request.UserId &&
               x.IsActive &&
               x.Role.IsActive
            , cancellationToken);

         return RoleHandlerHelper.GetTokenResult(user, _settings);
      }
   }
}
