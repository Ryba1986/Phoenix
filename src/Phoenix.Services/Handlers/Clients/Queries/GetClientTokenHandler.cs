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
   internal sealed class GetClientTokenHandler : HandlerBase, IRequestHandler<GetClientTokenQuery, TokenResult>
   {
      private readonly JwtSettings _settings;

      public GetClientTokenHandler(UnitOfWork uow, JwtSettings settings) : base(uow)
      {
         _settings = settings;
      }

      public async Task<TokenResult> Handle(GetClientTokenQuery request, CancellationToken cancellationToken)
      {
         Client? client = await _uow.Client
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
               x.MacAddress == request.MacAddress &&
               x.IsActive
            , cancellationToken);

         if (client is null)
         {
            return new();
         }

         return JwtHandlerHelper.CreateClient(client.Id, _settings);
      }
   }
}
