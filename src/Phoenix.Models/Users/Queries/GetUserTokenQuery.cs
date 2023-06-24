using MediatR;
using Phoenix.Shared.Results;

namespace Phoenix.Models.Users.Queries
{
   public sealed class GetUserTokenQuery : IRequest<TokenResult>
   {
      public string Email { get; init; }
      public string Password { get; init; }

      public GetUserTokenQuery()
      {
         Email = string.Empty;
         Password = string.Empty;
      }
   }
}
