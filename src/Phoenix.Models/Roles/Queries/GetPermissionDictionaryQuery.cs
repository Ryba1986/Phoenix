using System.Collections.Generic;
using MediatR;

namespace Phoenix.Models.Roles.Queries
{
   public sealed class GetPermissionDictionaryQuery : IRequest<IReadOnlyCollection<KeyValuePair<int, string>>>
   {
   }
}
