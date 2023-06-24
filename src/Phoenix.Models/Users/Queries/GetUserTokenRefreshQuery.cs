using MediatR;
using Phoenix.Shared.Results;

namespace Phoenix.Models.Users.Queries
{
   public sealed class GetUserTokenRefreshQuery : IRequest<TokenResult>
   {
      public int UserId { get; init; }
   }
}
