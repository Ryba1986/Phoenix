using System.Collections.Generic;
using MediatR;

namespace Phoenix.Models.Roles.Queries
{
   public sealed class GetRoleDictionaryQuery : IRequest<IReadOnlyCollection<KeyValuePair<int, string>>>
   {
   }
}
