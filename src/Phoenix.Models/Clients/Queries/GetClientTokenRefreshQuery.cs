using MediatR;
using Phoenix.Shared.Results;

namespace Phoenix.Models.Clients.Queries
{
   public sealed class GetClientTokenRefreshQuery : IRequest<TokenResult>
   {
      public int ClientId { get; init; }
   }
}
