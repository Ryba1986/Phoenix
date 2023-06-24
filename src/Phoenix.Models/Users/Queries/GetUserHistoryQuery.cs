using System.Collections.Generic;
using MediatR;
using Phoenix.Models.Users.Dto;

namespace Phoenix.Models.Users.Queries
{
   public sealed class GetUserHistoryQuery : IRequest<IReadOnlyCollection<UserHistoryDto>>
   {
      public int UserId { get; init; }
   }
}
