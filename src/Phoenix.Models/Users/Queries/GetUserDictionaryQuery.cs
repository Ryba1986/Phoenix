using System.Collections.Generic;
using MediatR;

namespace Phoenix.Models.Users.Queries
{
   public sealed class GetUserDictionaryQuery : IRequest<IReadOnlyCollection<KeyValuePair<int, string>>>
   {
   }
}
