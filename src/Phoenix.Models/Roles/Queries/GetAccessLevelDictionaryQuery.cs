using System.Collections.Generic;
using MediatR;

namespace Phoenix.Models.Roles.Queries
{
   public sealed class GetAccessLevelDictionaryQuery : IRequest<IReadOnlyCollection<KeyValuePair<int, string>>>
   {
   }
}
