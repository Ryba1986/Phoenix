using System.Collections.Generic;
using MediatR;

namespace Phoenix.Models.Devices.Queries
{
   public sealed class GetDevicePlcTypeDictionaryQuery : IRequest<IReadOnlyCollection<KeyValuePair<int, string>>>
   {
   }
}
