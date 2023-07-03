using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Client.Extensions;
using Phoenix.Client.Handlers.Base;
using Phoenix.Models.Clients.Queries;
using Phoenix.Shared.Results;
using RestSharp;

namespace Phoenix.Client.Handlers.Clients.Queries
{
   internal sealed class GetClientTokenHandler : HandlerBase, IRequestHandler<GetClientTokenQuery, TokenResult>
   {
      public GetClientTokenHandler(IRestClient client) : base(client)
      {
      }

      public async Task<TokenResult> Handle(GetClientTokenQuery request, CancellationToken cancellationToken)
      {
         TokenResult result = await _client.PostAsync("client/getClientToken", request, cancellationToken);
         _client.SetToken(result.Value);

         return result;
      }
   }
}
