using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Models.Devices.Queries;
using Phoenix.Shared.Enums.Devices;
using Phoenix.Shared.Extensions;

namespace Phoenix.Services.Handlers.Devices.Queries
{
   internal sealed class GetDeviceDataBitDictionaryHandler : IRequestHandler<GetDeviceDataBitDictionaryQuery, IReadOnlyCollection<KeyValuePair<int, string>>>
   {
      public async Task<IReadOnlyCollection<KeyValuePair<int, string>>> Handle(GetDeviceDataBitDictionaryQuery request, CancellationToken cancellationToken)
      {
         return await Task.FromResult(EnumExtensions.GetValues<SerialDataBits>().ToArray());
      }
   }
}
