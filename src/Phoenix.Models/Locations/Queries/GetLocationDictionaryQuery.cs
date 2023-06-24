using System.Collections.Generic;
using MediatR;

namespace Phoenix.Models.Locations.Queries
{
   public sealed class GetLocationDictionaryQuery : IRequest<IReadOnlyCollection<KeyValuePair<int, string>>>
   {
   }
}
