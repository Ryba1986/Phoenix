using MediatR;
using Phoenix.Shared.Results;

namespace Phoenix.Models.Clients.Queries
{
   public sealed class GetClientTokenQuery : IRequest<TokenResult>
   {
      public string MacAddress { get; init; }

      public GetClientTokenQuery()
      {
         MacAddress = string.Empty;
      }
   }
}
