using System.Collections.Generic;
using MediatR;
using Phoenix.Models.Users.Dto;

namespace Phoenix.Models.Users.Queries
{
   public sealed class GetUsersQuery : IRequest<IReadOnlyCollection<UserDto>>
   {
   }
}
