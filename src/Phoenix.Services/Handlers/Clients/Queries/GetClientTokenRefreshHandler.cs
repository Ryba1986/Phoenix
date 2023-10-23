using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Clients;
using Phoenix.Models.Clients.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Helpers;
using Phoenix.Services.Repositories;
using Phoenix.Services.Settings;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Clients.Queries
{
   internal sealed class GetClientTokenRefreshHandler : HandlerBase, IRequestHandler<GetClientTokenRefreshQuery, TokenResult>
   {
      private readonly JwtSettings _settings;

      public GetClientTokenRefreshHandler(UnitOfWork uow, JwtSettings settings) : base(uow)
      {
         _settings = settings;
      }

      public async Task<TokenResult> Handle(GetClientTokenRefreshQuery request, CancellationToken cancellationToken)
      {
         Client? client = await _uow.Client
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
               x.Id == request.ClientId &&
               x.IsActive
            , cancellationToken);

         return client is null
            ? new()
            : JwtHandlerHelper.CreateClient(client.Id, _settings);
      }
   }
}
