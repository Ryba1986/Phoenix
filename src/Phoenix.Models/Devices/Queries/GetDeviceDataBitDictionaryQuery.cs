using System.Collections.Generic;
using MediatR;

namespace Phoenix.Models.Devices.Queries
{
   public sealed class GetDeviceDataBitDictionaryQuery : IRequest<IReadOnlyCollection<KeyValuePair<int, string>>>
   {
   }
}
