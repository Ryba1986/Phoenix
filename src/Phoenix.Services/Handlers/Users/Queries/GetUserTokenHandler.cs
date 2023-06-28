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
            .Include(x => x.Role)
            .ThenInclude(x => x.Permissions)
            .FirstOrDefaultAsync(x =>
               x.Email == request.Email &&
               x.Password == request.Password.CreatePassword() &&
               x.IsActive &&
               x.Role.IsActive
            , cancellationToken);

         return RoleHandlerHelper.GetTokenResult(user, _settings);
      }
   }
}
